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
        var result = await _context.Cargos.ToListAsync();
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
        try
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
                throw new InvalidOperationException("Cargo must be either in a warehouse or in a plane.");
            }

            await _context.Cargos.AddAsync(cargo);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding cargo: {ex.Message}");
            throw;
        }
    }
    
    // PUT one cargo
    public async Task UpdateCargoAsync(Cargo updatedCargo, int id)
    {
        var dbCargo = await _context.Cargos.FindAsync(id);
        if (dbCargo != null)
        {
            dbCargo.CargoCode = updatedCargo.CargoCode;
            dbCargo.Description = updatedCargo.Description;
            dbCargo.Weight = updatedCargo.Weight;
            dbCargo.Status = updatedCargo.Status;

            if (updatedCargo.Status == CargoStatus.InWarehouse && updatedCargo.WarehouseId == null)
            {
                throw new InvalidOperationException("Cargo must be assigned to a warehouse.");
            }

            if (updatedCargo.Status == CargoStatus.InPlane && updatedCargo.AirplaneId == null)
            {
                throw new InvalidOperationException("Cargo must be assigned to an airplane.");
            }

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
        else
        {
            throw new Exception("Cargo not found");
        }
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
}
