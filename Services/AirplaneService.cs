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
    
    //GET one airplane
    public async Task<Airplane> GetAirplaneByIdAsync(int id)
    {
        return await _context.Airplanes
            .FirstOrDefaultAsync(a => a.AirplaneId == id);
    }
    
    //POST new airplane
    public async Task AddAirplaneAsync(Airplane airplane)
    {
        airplane.CurrentLoad = 0;
        await _context.Airplanes.AddAsync(airplane);
        await _context.SaveChangesAsync();
    }
    
    //PUT update one airplane
    public async Task UpdateAirplaneAsync(Airplane airplane, int id)
    {
        var dbAirplane = await _context.Airplanes.FindAsync(id);
        if (dbAirplane != null)
        {
            dbAirplane.AirplaneCode = airplane.AirplaneCode;
            dbAirplane.MaxLoad = airplane.MaxLoad;
            dbAirplane.CurrentLoad = airplane.CurrentLoad;
            dbAirplane.WarehouseId = airplane.WarehouseId;
            
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new Exception("Airplane not found");
        }
    }
    
    //DELETE one airplane
    public async Task DeleteAirplaneAsync(int id)
    {
        var airplane = await _context.Airplanes.FindAsync(id);
        if (airplane != null)
        {
            _context.Airplanes.Remove(airplane);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new Exception("Airplane not found");
        }
    }
    
    
    //GET all airplanes that are attached to a particular warehouse by id
    public async Task<List<Airplane>> GetAirplanesByWarehouseIdAsync(int WarehouseId)
    {
        return await _context.Airplanes
            .Where(a => a.WarehouseId == WarehouseId)
            .ToListAsync();
    }    
    

}