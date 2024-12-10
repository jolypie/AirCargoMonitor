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
            .FirstOrDefaultAsync(a => a.CargoId == id);
    }
    
    
    // POST one cargo
    public async Task AddCargoAsync(Cargo cargo)
    {
        if (cargo.Status == default)
        {
            cargo.Status = CargoStatus.InWarehouse; // Статус по умолчанию
        }

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
