using GoalsetterChallenge.Domain.Entities;

namespace GoalsetterChallenge.Domain.Abstract;
public interface IVehicleService
{
    Task<List<Vehicle>> GetAll();
    Task<Vehicle> Add(Vehicle vehicle);
    Task<bool> Remove(int vehicleId);
}