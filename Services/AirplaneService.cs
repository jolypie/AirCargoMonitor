using CargosMonitor.Data;
using CargosMonitor.Models;
using Microsoft.EntityFrameworkCore;

namespace CargosMonitor.Services;

public class AirplaneService : IAirplaneService
{
    private readonly DataContext _context;

    public AirplaneService(DataContext context)
    {
        _context = context;
    }

    // GET all airplanes
    public async Task<List<Airplane>> GetAllAirplanesAsync()
    {
        return await _context.Airplanes.AsNoTracking().ToListAsync();
    }

    // GET one airplane by ID
    public async Task<Airplane> GetAirplaneByIdAsync(int id)
    {
        var airplane = await _context.Airplanes.AsNoTracking().FirstOrDefaultAsync(a => a.AirplaneId == id);
        if (airplane == null)
        {
            throw new InvalidOperationException("Airplane not found.");
        }
        return airplane;
    }

    // POST new airplane
    public async Task AddAirplaneAsync(Airplane airplane)
    {
        if (string.IsNullOrWhiteSpace(airplane.AirplaneCode))
        {
            throw new InvalidOperationException("AirplaneCode is required and cannot be empty.");
        }
        if (airplane.AirplaneCode.Length > 10)
        {
            throw new InvalidOperationException("AirplaneCode must be 10 characters or fewer.");
        }
        if (airplane.MaxLoad <= 0)
        {
            throw new InvalidOperationException("MaxLoad must be greater than zero.");
        }
        if (airplane.WarehouseId <= 0)
        {
            throw new InvalidOperationException("Valid WarehouseId is required.");
        }

        var codeExists = await _context.Airplanes.AnyAsync(a => a.AirplaneCode == airplane.AirplaneCode);
        if (codeExists)
        {
            throw new InvalidOperationException("AirplaneCode must be unique.");
        }

        var warehouseExists = await _context.Warehouses.AnyAsync(w => w.WarehouseId == airplane.WarehouseId);
        if (!warehouseExists)
        {
            throw new InvalidOperationException("Warehouse not found.");
        }

        airplane.CurrentLoad = 0;

        _context.Airplanes.Add(airplane);
        await _context.SaveChangesAsync();
    }

    // PUT update airplane
    public async Task UpdateAirplaneAsync(Airplane airplane, int id)
    {
        var dbAirplane = await _context.Airplanes.FindAsync(id);
        if (dbAirplane == null)
        {
            throw new InvalidOperationException("Airplane not found.");
        }

        // Validate inputs
        if (string.IsNullOrWhiteSpace(airplane.AirplaneCode))
        {
            throw new InvalidOperationException("AirplaneCode is required and cannot be empty.");
        }
        if (airplane.AirplaneCode.Length > 10)
        {
            throw new InvalidOperationException("AirplaneCode must be 10 characters or fewer.");
        }
        if (airplane.MaxLoad <= 0)
        {
            throw new InvalidOperationException("MaxLoad must be greater than zero.");
        }
        if (airplane.CurrentLoad < 0 || airplane.CurrentLoad > airplane.MaxLoad)
        {
            throw new InvalidOperationException("CurrentLoad must be between 0 and MaxLoad.");
        }
        if (airplane.WarehouseId <= 0)
        {
            throw new InvalidOperationException("Valid WarehouseId is required.");
        }

        // Check if Warehouse exists
        var warehouseExists = await _context.Warehouses.AnyAsync(w => w.WarehouseId == airplane.WarehouseId);
        if (!warehouseExists)
        {
            throw new InvalidOperationException("Warehouse not found.");
        }

        // Update airplane properties
        dbAirplane.AirplaneCode = airplane.AirplaneCode;
        dbAirplane.MaxLoad = airplane.MaxLoad;
        dbAirplane.CurrentLoad = airplane.CurrentLoad;
        dbAirplane.WarehouseId = airplane.WarehouseId;

        await _context.SaveChangesAsync();
    }

    // DELETE airplane by ID
    public async Task DeleteAirplaneAsync(int id)
    {
        var airplane = await _context.Airplanes.FindAsync(id);
        if (airplane == null)
        {
            throw new InvalidOperationException("Airplane not found.");
        }

        _context.Airplanes.Remove(airplane);
        await _context.SaveChangesAsync();
    }

    // GET all airplanes by WarehouseId
    public async Task<List<Airplane>> GetAirplanesByWarehouseIdAsync(int warehouseId)
    {
        var warehouseExists = await _context.Warehouses.AnyAsync(w => w.WarehouseId == warehouseId);
        if (!warehouseExists)
        {
            throw new InvalidOperationException("Warehouse not found.");
        }

        return await _context.Airplanes.AsNoTracking()
            .Where(a => a.WarehouseId == warehouseId)
            .ToListAsync();
    }
}
