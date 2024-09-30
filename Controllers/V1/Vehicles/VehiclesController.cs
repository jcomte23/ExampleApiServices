using ExampleApiServices.Data;
using ExampleApiServices.DTOs;
using ExampleApiServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ExampleApiServices.Controllers.V1.Vehicles;

[ApiController]
[Route("api/v1/[controller]")]
public class VehiclesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public VehiclesController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Vehicle>>> GetAll()
    {
        return await _context.Vehicles.ToListAsync();
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Vehicle>> GetById(int id)
    {
        var vehicle = await _context.Vehicles.FindAsync(id);
        if (vehicle == null)
        {
            return NotFound();
        }
        return vehicle;
    }

    [HttpPost]
    public async Task<ActionResult<Vehicle>> Create(VehicleDTO inputVehicle)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var newVehicle = new Vehicle(inputVehicle.Make, inputVehicle.Model, inputVehicle.Year, inputVehicle.Price, inputVehicle.Color);

        _context.Vehicles.Add(newVehicle);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = newVehicle.Id }, inputVehicle);
    }

    // Actualizar un vehículo existente
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, VehicleDTO updatedVehicle)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var vehicle = await _context.Vehicles.FindAsync(id);
        if (vehicle == null)
        {
            return NotFound();
        }

        vehicle.Make = updatedVehicle.Make;
        vehicle.Model = updatedVehicle.Model;
        vehicle.Year = updatedVehicle.Year;
        vehicle.Price = updatedVehicle.Price;
        vehicle.Color = updatedVehicle.Color;

        _context.Vehicles.Update(vehicle);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // Eliminar un vehículo
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var vehicle = await _context.Vehicles.FindAsync(id);
        if (vehicle == null)
        {
            return NotFound();
        }

        _context.Vehicles.Remove(vehicle);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
