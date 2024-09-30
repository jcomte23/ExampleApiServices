using ExampleApiServices.Models;

namespace ExampleApiServices.Repositories;
public interface IVehicleRepository
{
    Task<IEnumerable<Vehicle>> GetAll();
    Task<Vehicle?> GetById(int id);
    Task Add(Vehicle vehicle);
    Task Update(Vehicle vehicle);
    Task<bool> CheckExistence(int id);
}
