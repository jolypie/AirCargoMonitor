using CargosMonitor.Models;

namespace CargosMonitor.Services;

public interface ICargoService
{
    Task<List<Cargo>> GetAllCargosAsync();
    Task<Cargo> GetCargoByIdAsync(int id);
    Task AddCargoAsync(Cargo cargo);
    Task UpdateCargoAsync(Cargo cargo, int id);
    Task DeleteCargoAsync(int id);
    
    Task<List<Cargo>> GetCargosByWarehouseIdAsync(int warehouseId);
    Task<List<Cargo>> GetCargosByAirplaneIdAsync(int airplaneId);
    Task<List<Cargo>> GetCargosInWarehousesAsync();
    Task<List<Cargo>> GetCargosInAirplanesAsync();
    
    Task AddCargoToAirplaneAsync(int cargoId, int airplaneId);
    Task RemoveCargoFromAirplaneAsync(int cargoId);
    
    Task<List<Cargo>> GetCargosInAirplanesByWarehouseIdAsync(int warehouseId);

    
    

}
