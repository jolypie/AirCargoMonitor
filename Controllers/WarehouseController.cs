using CargosMonitor.Models;
using CargosMonitor.Services;
using Microsoft.AspNetCore.Mvc;

namespace CargosMonitor.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WarehouseController : ControllerBase
{
    private readonly IWarehouseService _warehouseService;

    public WarehouseController(IWarehouseService warehouseService)
    {
        _warehouseService = warehouseService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Warehouse>>> GetAllWarehouses()
    {
        var warehouses = await _warehouseService.GetAllWarehousesAsync();
        return Ok(warehouses);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Warehouse>> GetWarehouseById(int id)
    {
        var warehouse = await _warehouseService.GetWarehouseByIdAsync(id);
        if (warehouse == null) return NotFound();
        return Ok(warehouse);
    }

    [HttpPost]
    public async Task<ActionResult> AddWarehouse(Warehouse warehouse)
    {
        await _warehouseService.AddWarehouseAsync(warehouse);
        return CreatedAtAction(nameof(GetWarehouseById), new { id = warehouse.WarehouseId }, warehouse);
    }

    [HttpPut("{id:int}")]
    
    public async Task<ActionResult> UpdateWarehouse(int id, [FromBody] Warehouse updatedWarehouse)
    {
        var dbWarehouse = await _warehouseService.GetWarehouseByIdAsync(id);
        if (dbWarehouse == null)
        {
            return NotFound($"Warehouse with ID {id} not found.");
        }

        await _warehouseService.UpdateWarehouseAsync(updatedWarehouse, id);
        return Ok(updatedWarehouse);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteWarehouse(int id)
    {
        var dbWarehouse = await _warehouseService.GetWarehouseByIdAsync(id);
        if (dbWarehouse == null)
        {
            return NotFound($"Warehouse with ID {id} not found.");
        }

        await _warehouseService.DeleteWarehouseAsync(id);
        var warehouses = await _warehouseService.GetAllWarehousesAsync();
        return Ok(warehouses);
    }
}