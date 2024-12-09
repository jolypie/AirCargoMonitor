using CargosMonitor.Data;
using CargosMonitor.Models;
using Microsoft.EntityFrameworkCore;

namespace CargosMonitor.Services;

public class AirplaneService : IAirplaneService

{
    private readonly DataContext _context;

    public AirplaneService(DataContext context)
    {
        _context = context;
    }

    // GET all airplanes
    public async Task<List<Airplane>> GetAllAirplanesAsync()
    {
        var result = await _context.Airplanes.ToListAsync();
        return result;
    }
}