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
        return await _context.Warehouses
            .FirstOrDefaultAsync(w => w.WarehouseId == id);
    }
    
    //POST new warehouse
    public async Task AddWarehouseAsync(Warehouse warehouse)
    {
        await _context.Warehouses.AddAsync(warehouse);
        await _context.SaveChangesAsync();
    }
    
    //PUT update warehouse
    public async Task UpdateWarehouseAsync(Warehouse warehouse, int id)
    {
        var dbWarehouse = await _context.Warehouses.FindAsync(id);
        if (dbWarehouse != null)
        {
            dbWarehouse.WarehouseCode = warehouse.WarehouseCode;
            dbWarehouse.Location = warehouse.Location;
            
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new Exception("Warehouse not found");
        }
    }
    
    //DELETE warehouse
    public async Task DeleteWarehouseAsync(int id)
    {
        var warehouse = await _context.Warehouses.FindAsync(id);
        if (warehouse != null)
        {
            _context.Warehouses.Remove(warehouse);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new Exception("Warehouse not found");
        }
    }
}