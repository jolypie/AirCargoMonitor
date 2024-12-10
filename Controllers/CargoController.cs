using CargosMonitor.Models;
using CargosMonitor.Services;
using Microsoft.AspNetCore.Mvc;

namespace CargosMonitor.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CargoController : ControllerBase
{
    private readonly ICargoService _cargoService;

    public CargoController(ICargoService cargoService)
    {
        _cargoService = cargoService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Cargo>>> GetAllCargos()
    {
        var cargos = await _cargoService.GetAllCargosAsync();
        return Ok(cargos);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Cargo>> GetCargoById(int id)
    {
        var cargo = await _cargoService.GetCargoByIdAsync(id);
        if(cargo == null) return NotFound();
        return Ok(cargo);
    }

    [HttpPost]
    public async Task<ActionResult> PostCargo(Cargo cargo)
    {
        await _cargoService.AddCargoAsync(cargo);
        return CreatedAtAction(nameof(GetCargoById), new { id = cargo.CargoId }, cargo);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Cargo>> PutCargo(int id, [FromBody] Cargo updatedCargo)
    {
        var dbCargo = await _cargoService.GetCargoByIdAsync(id);
        if (dbCargo == null)
        {
            return NotFound($"Cargo with ID {id} not found.");
        }
        await _cargoService.UpdateCargoAsync(updatedCargo, id);
        return Ok(updatedCargo);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Cargo>> DeleteCargo(int id)
    {
        var dbCargo = await _cargoService.GetCargoByIdAsync(id);
        if (dbCargo == null)
        {
            return NotFound($"Cargo with ID {id} not found.");
        }
        await _cargoService.DeleteCargoAsync(id);
        var cargos = await _cargoService.GetAllCargosAsync();
        return Ok(cargos);
    }
}











