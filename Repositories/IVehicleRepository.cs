using ExampleApiServices.Models;

namespace ExampleApiServices.Repositories;
public interface IVehicleRepository
{
    Task<IEnumerable<Vehicle>> GetAll();
    Task<Vehicle?> GetById(int id);
    Task<IEnumerable<Vehicle>> GetByKeyword(string keyword);
    Task Add(Vehicle vehicle);
    Task Update(Vehicle vehicle);
    Task Delete(int id);
    Task<bool> CheckExistence(int id);
}
