using CargosMonitor.Models;

namespace CargosMonitor.Services;

public interface IWarehouseService
{
    Task<List<Warehouse>> GetAllWarehousesAsync();
    Task<Warehouse> GetWarehouseByIdAsync(int id);
    Task AddWarehouseAsync(Warehouse warehouse);
    Task UpdateWarehouseAsync(Warehouse warehouse, int id);
    Task DeleteWarehouseAsync(int id);

    // Cargos
    // Task<List<Cargo>> GetCargosInWarehouseAsync(int warehouseId);
    // Task AddCargoToWarehouseAsync(int warehouseId, int cargoId);
    // Task DeleteCargoFromWarehouseAsync(int warehouseId, int cargoId);

    // Airplanes
    // Task<List<Airplane>> GetAirplanesInWarehouseAsync(int warehouseId);
    // Task AddAirplaneToWarehouseAsync(int warehouseId, int airplaneId);
    // Task DeleteAirplaneFromWarehouseAsync(int warehouseId, int airplaneId);
}