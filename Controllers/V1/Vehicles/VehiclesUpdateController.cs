using ExampleApiServices.Data;
using ExampleApiServices.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ExampleApiServices.Controllers.V1.Vehicles;

[ApiController]
[Route("api/v1/[controller]")]
public class VehiclesUpdateController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public VehiclesUpdateController(ApplicationDbContext context)
    {
        _context = context;
    }

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
}
