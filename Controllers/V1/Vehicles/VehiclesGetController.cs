using ExampleApiServices.Data;
using ExampleApiServices.DTOs;
using ExampleApiServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ExampleApiServices.Controllers.V1.Vehicles;

[ApiController]
[Route("api/v1/[controller]")]
public class VehiclesGetController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public VehiclesGetController(ApplicationDbContext context)
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

    [HttpGet("search/{keyword}")]
    public async Task<ActionResult<IEnumerable<Vehicle>>> SearchByKeyword(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
        {
            return BadRequest("La palabra clave no puede estar vacía.");
        }

        var vehicles = await _context.Vehicles
            .Where(v => v.Make.Contains(keyword) ||
                        v.Model.Contains(keyword) ||
                        v.Color.Contains(keyword))
            .ToListAsync();

        if (!vehicles.Any())
        {
            return NotFound("No se encontraron vehículos que coincidan con la palabra clave proporcionada.");
        }

        return Ok(vehicles);
    }
}
