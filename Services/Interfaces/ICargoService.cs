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
}
