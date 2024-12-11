using CargosMonitor.Models;

namespace CargosMonitor.Services;

public interface IWarehouseService
{
    Task<List<Warehouse>> GetAllWarehousesAsync();
    Task<Warehouse> GetWarehouseByIdAsync(int id);
    Task AddWarehouseAsync(Warehouse warehouse);
    Task UpdateWarehouseAsync(Warehouse warehouse, int id);
    Task DeleteWarehouseAsync(int id);
}