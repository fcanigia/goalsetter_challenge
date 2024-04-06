using GoalsetterChallenge.Domain.Entities;
using GoalsetterChallenge.WebApi.Dto;

namespace GoalsetterChallenge.AppCore.Services;
public interface IRentalService
{
    Task<Rental> Create(RentalInDto rental);
    Task<List<Rental>> GetAll();
    Task<bool> Remove(int rentalId);
}