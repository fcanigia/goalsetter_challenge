using GoalsetterChallenge.Domain.Entities;
using GoalsetterChallenge.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GoalsetterChallenge.AppCore.Services;

public class RentalService : IRentalService
{
    private readonly RentalDbContext _context;

    public RentalService(RentalDbContext context)
    {
        _context = context;
    }

    public async Task<List<Rental>> GetAll()
    {
        var rentals = await _context.Rentals.ToListAsync();

        return rentals;
    }

    public async Task<Rental> Create(Rental rental)
    {
        try
        {
            _context.Rentals.Add(rental);

            await _context.SaveChangesAsync();

            return rental;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<bool> Remove(int rentalId)
    {
        try
        {
            var rentalToRemove = await _context.Rentals.FindAsync(rentalId);

            if (rentalToRemove == null)
            {
                return false;
            }

            rentalToRemove.IsRemoved = true;
            await _context.SaveChangesAsync();

            return true;

        }
        catch (Exception)
        {

            throw;
        }
    }
}
