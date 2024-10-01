using ExampleApiServices.Data;
using ExampleApiServices.Models;
using ExampleApiServices.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExampleApiServices.Services;

public class VehicleServices : IVehicleRepository
{
    private readonly ApplicationDbContext _context;

    public VehicleServices(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Add(Vehicle vehicle)
    {
        if (vehicle == null)
        {
            throw new ArgumentNullException(nameof(vehicle), "El vehículo no puede ser nulo.");
        }

        try
        {
            await _context.Vehicles.AddAsync(vehicle);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Error al agregar el vehículo a la base de datos.", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Ocurrió un error inesperado al agregar el vehículo.", ex);
        }
    }

    public async Task<bool> CheckExistence(int id)
    {
        try
        {
            return await _context.Vehicles.AnyAsync(v => v.Id == id);
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Error al agregar el vehículo a la base de datos.", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Ocurrió un error inesperado al agregar el vehículo.", ex);
        }

    }

    public async Task Delete(int id)
    {
        var vehicle = await _context.Vehicles.FindAsync(id);
        if (vehicle!= null)
        {
            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Vehicle>> GetAll()
    {
        return await _context.Vehicles.ToListAsync();
    }

    public async Task<Vehicle?> GetById(int id)
    {
        return await _context.Vehicles.FindAsync(id);
    }

    public async Task Update(Vehicle vehicle)
    {
        if (vehicle == null)
        {
            throw new ArgumentNullException(nameof(vehicle), "El vehículo no puede ser nulo.");
        }

        try
        {
            _context.Entry(vehicle).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Error al actualizar el vehículo en la base de datos.", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Ocurrió un error inesperado al actualizar el vehículo.", ex);
        }
    }
}
