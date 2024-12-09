using CargosMonitor.Models;

namespace CargosMonitor.Services;

public interface IWarehouseService
{
    Task<List<Warehouse>> GetAllWarehouses();
    
}