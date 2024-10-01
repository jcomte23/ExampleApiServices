using ExampleApiServices.Data;
using ExampleApiServices.DTOs;
using ExampleApiServices.Models;
using ExampleApiServices.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ExampleApiServices.Controllers.V1.Vehicles;

[ApiController]
[Route("api/v1/[controller]")]
public class VehiclesGetController : ControllerBase
{
    private readonly IVehicleRepository _vehicleRepository;

    public VehiclesGetController(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Vehicle>>> GetAll()
    {
        var vehicles = await _vehicleRepository.GetAll();
        return Ok(vehicles);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Vehicle>> GetById(int id)
    {
        var vehicle = await _vehicleRepository.GetById(id);
        if (vehicle == null)
        {
            return NotFound();
        }
        return vehicle;
    }

    [HttpGet("search/{keyword}")]
    public async Task<ActionResult<IEnumerable<Vehicle>>> SearchByKeyword(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
        {
            return BadRequest("La palabra clave no puede estar vacía.");
        }

        var vehicles = await _vehicleRepository.GetByKeyword(keyword);

        if (!vehicles.Any())
        {
            return NotFound("No se encontraron vehículos que coincidan con la palabra clave proporcionada.");
        }

        return Ok(vehicles);
    }
}
