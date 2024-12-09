using CargosMonitor.Models;

namespace CargosMonitor.Services;

public interface IAirplaneService
{
    Task<List<Airplane>> GetAllAirplanesAsync();
}