using ExampleApiServices.Data;
using ExampleApiServices.DTOs;
using ExampleApiServices.Models;
using ExampleApiServices.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExampleApiServices.Controllers.V1.Vehicles;

[ApiController]
[Route("api/v1/vehicles")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("vehicles")]
public class VehiclesCreateController(IVehicleRepository vehicleRepository) : VehiclesController(vehicleRepository)
{
    [HttpPost]
    public async Task<ActionResult<Vehicle>> Create(VehicleDTO inputVehicle)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var newVehicle = new Vehicle(inputVehicle.Make, inputVehicle.Model, inputVehicle.Year, inputVehicle.Price, inputVehicle.Color);

        await _vehicleRepository.Add(newVehicle);

        return Ok(newVehicle);
    }
}
