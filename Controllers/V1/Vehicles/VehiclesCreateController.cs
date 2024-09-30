using ExampleApiServices.Data;
using ExampleApiServices.DTOs;
using ExampleApiServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExampleApiServices.Controllers.V1.Vehicles;

[ApiController]
[Route("api/v1/[controller]")]
public class VehiclesCreateController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public VehiclesCreateController(ApplicationDbContext context)
    {
        _context = context;
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
        return Ok(newVehicle);
        // return CreatedAtAction(nameof(GetById), new { id = newVehicle.Id }, inputVehicle);
    }
}
