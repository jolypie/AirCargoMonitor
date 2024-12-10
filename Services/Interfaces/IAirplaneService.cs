using CargosMonitor.Models;

namespace CargosMonitor.Services;

public interface IAirplaneService
{
    Task<List<Airplane>> GetAllAirplanesAsync();
    Task<Airplane> GetAirplaneByIdAsync(int id);
    Task AddAirplaneAsync(Airplane airplane);
    Task UpdateAirplaneAsync(Airplane airplane, int id);
    Task DeleteAirplaneAsync(int id);
    
    Task<List<Airplane>> GetAirplanesByWarehouseIdAsync(int warehouseId);
}