using CargosMonitor.Data;
using CargosMonitor.Models;
using Microsoft.EntityFrameworkCore;

namespace CargosMonitor.Services;

public class CargoService : ICargoService
{
    private readonly DataContext _context;

    public CargoService(DataContext context)
    {
        _context = context;
    }

    // GET all cargos
    public async Task<List<Cargo>> GetAllCargosAsync()
    {
        var result = await _context.Cargos
            .Include(c => c.Warehouse)
            .Include(c => c.Airplane)
            .ToListAsync();
        return result;
    }
    
    // GET one cargo
    public async Task<Cargo> GetCargoByIdAsync(int id)
    {
        return await _context.Cargos
            .Include(c => c.Warehouse)
            .Include(c => c.Airplane)
            .FirstOrDefaultAsync(c => c.CargoId == id);
    }

    
    
    // POST one cargo
    public async Task AddCargoAsync(Cargo cargo)
    {
        if (string.IsNullOrWhiteSpace(cargo.CargoCode))
        {
            throw new ArgumentException("CargoCode is required.");
        }

        if (cargo.Weight <= 0)
        {
            throw new ArgumentException("Weight must be greater than zero.");
        }

        cargo.Status = cargo.Status == default ? CargoStatus.InWarehouse : cargo.Status;
        cargo.AddedToWarehouseAt = DateTime.UtcNow;

        ValidateCargoStatus(cargo);

        await _context.Cargos.AddAsync(cargo);
        await _context.SaveChangesAsync();
    }
    
    // PUT one cargo
    public async Task UpdateCargoAsync(Cargo updatedCargo, int id)
    {
        var dbCargo = await _context.Cargos.FindAsync(id)
                      ?? throw new Exception("Cargo not found");

        dbCargo.CargoCode = updatedCargo.CargoCode;
        dbCargo.Description = updatedCargo.Description;
        dbCargo.Weight = updatedCargo.Weight;
        dbCargo.Status = updatedCargo.Status;

        ValidateCargoStatus(updatedCargo);

        if (updatedCargo.Status == CargoStatus.InWarehouse)
        {
            dbCargo.WarehouseId = updatedCargo.WarehouseId;
            dbCargo.AirplaneId = null;
        }
        else if (updatedCargo.Status == CargoStatus.InPlane)
        {
            dbCargo.AirplaneId = updatedCargo.AirplaneId;
            dbCargo.WarehouseId = null;
        }

        await _context.SaveChangesAsync();
    }
    
    // DELETE one cargo
    public async Task DeleteCargoAsync(int id)
    {
        var cargo = await _context.Cargos.FindAsync(id);
        if (cargo != null)
        {
            _context.Cargos.Remove(cargo);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new Exception("Cargo not found");
        }
    }


    //GET all cargos that are attached to a particular warehouse by id
    public async Task<List<Cargo>> GetCargosByWarehouseIdAsync(int WarehouseId)
    {
        return await _context.Cargos
            .Where(c => c.WarehouseId == WarehouseId)
            .ToListAsync();
    }    
    
    //GET all cargos that are attached to a particular warehouse by id
    public async Task<List<Cargo>> GetCargosByAirplaneIdAsync(int AirplaneId)
    {
        return await _context.Cargos
            .Where(c => c.AirplaneId == AirplaneId)
            .ToListAsync();
    }
    
    //GET all cargos that are in a warehouses
    public async Task<List<Cargo>> GetCargosInWarehousesAsync()
    {
        return await _context.Cargos
            .Where(c => c.Status == CargoStatus.InWarehouse)
            .Include(c => c.Warehouse)
            .ToListAsync();
    }
    
        
    //GET all cargos that are in aiplanes
    public async Task<List<Cargo>> GetCargosInAirplanesAsync()
    {
        return await _context.Cargos
            .Where(c => c.Status == CargoStatus.InPlane)
            .Include(c => c.Airplane)
            .ToListAsync();
    }
    
    //POST one cargo by id to an airplane by id
    public async Task AddCargoToAirplaneAsync(int cargoId, int airplaneId)
    {
        var cargo = await _context.Cargos
            .Include(c => c.Airplane)
            .Include(c => c.Warehouse)
            .FirstOrDefaultAsync(c => c.CargoId == cargoId);

        if (cargo == null)
        {
            throw new Exception("Cargo not found.");
        }

        if (cargo.Status != CargoStatus.InWarehouse)
        {
            throw new InvalidOperationException("Only cargos in warehouses can be added to airplanes.");
        }

        var airplane = await _context.Airplanes
            .Include(a => a.Warehouse)
            .FirstOrDefaultAsync(a => a.AirplaneId == airplaneId);

        if (airplane == null)
        {
            throw new Exception("Airplane not found.");
        }

        if (cargo.WarehouseId != airplane.Warehouse?.WarehouseId)
        {
            throw new InvalidOperationException("The cargo and airplane must be in the same warehouse.");
        }

        if (airplane.CurrentLoad + cargo.Weight > airplane.MaxLoad)
        {
            throw new InvalidOperationException("The airplane does not have enough capacity for this cargo.");
        }

        cargo.Status = CargoStatus.InPlane;
        cargo.AirplaneId = airplaneId;
        cargo.WarehouseId = null;
        cargo.AddedToAirplaneAt = DateTime.UtcNow;
        cargo.AddedToWarehouseAt = null;

        airplane.CurrentLoad += cargo.Weight;

        await _context.SaveChangesAsync();
    }

    
    // POST one cargo from an airplane back to a warehouse
    public async Task RemoveCargoFromAirplaneAsync(int cargoId)
    {
        var cargo = await _context.Cargos
            .Include(c => c.Airplane)
            .FirstOrDefaultAsync(c => c.CargoId == cargoId);

        if (cargo == null)
        {
            throw new Exception("Cargo not found.");
        }

        if (cargo.Status != CargoStatus.InPlane)
        {
            throw new InvalidOperationException("Only cargos in airplanes can be moved back to warehouses.");
        }

        var airplane = cargo.Airplane;
        if (airplane == null)
        {
            throw new Exception("Airplane not found for the cargo.");
        }

        var warehouseId = airplane.WarehouseId;
        if (warehouseId == null)
        {
            throw new Exception("No warehouse associated with the airplane.");
        }

        airplane.CurrentLoad -= cargo.Weight;

        cargo.Status = CargoStatus.InWarehouse;
        cargo.WarehouseId = warehouseId;
        cargo.AirplaneId = null;
        cargo.AddedToWarehouseAt = DateTime.UtcNow;
        cargo.AddedToAirplaneAt = null;

        await _context.SaveChangesAsync();
    }

    
    
    private void ValidateCargoStatus(Cargo cargo)
    {
        if (cargo.Status == CargoStatus.InWarehouse && cargo.WarehouseId == null)
        {
            throw new InvalidOperationException("Cargo must be assigned to a warehouse.");
        }

        if (cargo.Status == CargoStatus.InPlane && cargo.AirplaneId == null)
        {
            throw new InvalidOperationException("Cargo must be assigned to an airplane.");
        }

        if (cargo.Status != CargoStatus.InWarehouse && cargo.Status != CargoStatus.InPlane)
        {
            throw new InvalidOperationException("Invalid cargo status.");
        }
    }
    

}
