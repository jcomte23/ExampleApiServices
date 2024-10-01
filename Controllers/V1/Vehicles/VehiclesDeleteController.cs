using ExampleApiServices.Data;
using ExampleApiServices.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExampleApiServices.Controllers.V1.Vehicles;

[ApiController]
[Route("api/v1/vehicles")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("vehicles")]
public class VehiclesDeleteController(IVehicleRepository vehicleRepository) : VehiclesController(vehicleRepository)
{
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var vehicle = await _vehicleRepository.CheckExistence(id);
        if (vehicle == false)
        {
            return NotFound();
        }

        await _vehicleRepository.Delete(id);

        return NoContent();
    }
}
