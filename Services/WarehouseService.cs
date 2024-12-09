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
    public async Task<List<Warehouse>> GetAllWarehouses()
    {
        var result = await _context.Warehouses.ToListAsync();
        return result;
    }
}