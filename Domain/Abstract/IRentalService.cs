using GoalsetterChallenge.Domain.Entities;

namespace GoalsetterChallenge.AppCore.Services;
public interface IRentalService
{
    Task<Rental> Create(Rental rental);
    Task<List<Rental>> GetAll();
    Task<bool> Remove(int rentalId);
}