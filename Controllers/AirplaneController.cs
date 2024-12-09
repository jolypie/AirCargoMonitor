using CargosMonitor.Models;
using CargosMonitor.Services;
using Microsoft.AspNetCore.Mvc;

namespace CargosMonitor.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AirplaneController : ControllerBase
{
    private readonly IAirplaneService _airplaneService;
    
    public AirplaneController(IAirplaneService airplaneService)
    {
        _airplaneService = airplaneService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Airplane>>> GetAllAirplanes()
    {
        var airplanes = await _airplaneService.GetAllAirplanesAsync();
        return Ok(airplanes);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Airplane>> GetAirplaneById(int id)
    {
        var airplane = await _airplaneService.GetAirplaneByIdAsync(id);
        if (airplane == null) return NotFound();
        return Ok(airplane);
    }
    
    [HttpPost]
    public async Task<ActionResult> AddAirplane(Airplane airplane)
    {
        await _airplaneService.AddAirplaneAsync(airplane);
        return CreatedAtAction(nameof(GetAirplaneById), new { id = airplane.AirplaneId }, airplane);
    }
    
    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateAirplane(int id, [FromBody] Airplane updatedAirplane)
    {
        var dbAirplane = await _airplaneService.GetAirplaneByIdAsync(id);
        if (dbAirplane == null)
        {
            return NotFound($"Airplane with ID {id} not found.");
        }
        await _airplaneService.UpdateAirplaneAsync(updatedAirplane, id);
        return Ok(updatedAirplane);
    }
    
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteAirplane(int id)
    {
        var dbAirplane = await _airplaneService.GetAirplaneByIdAsync(id);
        if (dbAirplane == null)
        {
            return NotFound($"Airplane with ID {id} not found.");
        }
        await _airplaneService.DeleteAirplaneAsync(id);
        var airplanes = await _airplaneService.GetAllAirplanesAsync();
        return Ok(airplanes);
    }
}