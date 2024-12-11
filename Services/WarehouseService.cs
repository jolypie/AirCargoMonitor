using CargosMonitor.Data;
using CargosMonitor.Models;
using Microsoft.EntityFrameworkCore;

namespace CargosMonitor.Services;

public class WarehouseService : IWarehouseService
{
    private readonly DataContext _context;
    
    
    public WarehouseService(DataContext context)
    {
        _context = context;
    }
    
    // GET all warehouses
    public async Task<List<Warehouse>> GetAllWarehousesAsync()
    {
        var result = await _context.Warehouses.ToListAsync();
        return result;
    }
    
    // GET one warehouse
    public async Task<Warehouse> GetWarehouseByIdAsync(int id)
    {
        var warehouse = await _context.Warehouses.FirstOrDefaultAsync(w => w.WarehouseId == id);
        if (warehouse == null)
        {
            throw new Exception("Warehouse not found.");
        }
        return warehouse;
    }
    
    //POST new warehouse
    public async Task AddWarehouseAsync(Warehouse warehouse)
    {
        ValidateWarehouse(warehouse);
        await _context.Warehouses.AddAsync(warehouse);
        await _context.SaveChangesAsync();
    }
    
    //PUT update warehouse
    public async Task UpdateWarehouseAsync(Warehouse warehouse, int id)
    {
        var dbWarehouse = await _context.Warehouses.FindAsync(id);
        if (dbWarehouse == null)
        {
            throw new Exception("Warehouse not found.");
        }

        dbWarehouse.WarehouseCode = warehouse.WarehouseCode;
        dbWarehouse.Location = warehouse.Location;

        ValidateWarehouse(dbWarehouse);

        await _context.SaveChangesAsync();
    }
    
    //DELETE warehouse
    public async Task DeleteWarehouseAsync(int id)
    {
        var warehouse = await _context.Warehouses.FindAsync(id);
        if (warehouse == null)
        {
            throw new Exception("Warehouse not found.");
        }

        _context.Warehouses.Remove(warehouse);
        await _context.SaveChangesAsync();
    }
    
    private void ValidateWarehouse(Warehouse warehouse)
    {
        if (warehouse == null)
        {
            throw new ArgumentNullException(nameof(warehouse), "Warehouse cannot be null.");
        }

        if (string.IsNullOrWhiteSpace(warehouse.WarehouseCode))
        {
            throw new InvalidOperationException("WarehouseCode is required and cannot be empty.");
        }

        if (warehouse.WarehouseCode.Length > 5)
        {
            throw new InvalidOperationException("WarehouseCode must not exceed 5 characters.");
        }

        if (!System.Text.RegularExpressions.Regex.IsMatch(warehouse.WarehouseCode, "^[A-Za-z0-9]+$"))
        {
            throw new InvalidOperationException("WarehouseCode can only contain alphanumeric characters.");
        }

        if (string.IsNullOrWhiteSpace(warehouse.Location))
        {
            throw new InvalidOperationException("Location is required and cannot be empty.");
        }

        if (warehouse.Location.Length > 100)
        {
            throw new InvalidOperationException("Location must not exceed 100 characters.");
        }
    }

}