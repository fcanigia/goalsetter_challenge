using GoalsetterChallenge.Domain.Abstract;
using GoalsetterChallenge.Domain.Entities;
using GoalsetterChallenge.Infrastructure.Context;
using GoalsetterChallenge.Tools.CustomExceptions;
using GoalsetterChallenge.WebApi.Dto;
using Microsoft.EntityFrameworkCore;

namespace GoalsetterChallenge.AppCore.Services;

public class RentalService : IRentalService
{
    private readonly RentalDbContext _context;
    private readonly IClientService _clientService;
    private readonly IVehicleService _vehicleService;

    public RentalService(RentalDbContext context,
        IClientService clientService,
        IVehicleService vehicleService)
    {
        _context = context;
        _clientService = clientService;
        _vehicleService = vehicleService;
    }

    public async Task<List<Rental>> GetAll()
    {
        var rentals = await _context.Rentals.ToListAsync();

        return rentals;
    }

    public async Task<Rental> Create(RentalInDto rental)
    {
        try
        {
            ValidateDates(rental);

            var vehicle = await _vehicleService.GetById(rental.VehicleId);

            if (vehicle.IsRemoved)
            {
                throw new ValidationException($"Vehicle with Id {vehicle.Id} was removed from the Rental and cannot be selected");
            }

            var client = await _clientService.GetById(rental.ClientId);

            if (client.IsRemoved)
            {
                throw new ValidationException($"Client with Id {client.Id} was removed from the Rental and cannot rent new cars");
            }

            var newRental = new Rental()
            {
                ClientId = client.Id,
                VehicleId = vehicle.Id,
                StartDate = rental.StartDate,
                EndDate = rental.EndDate
            };

            _context.Rentals.Add(newRental);

            await _context.SaveChangesAsync();

            return newRental;
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

    private static void ValidateDates(RentalInDto rental)
    {
        if (rental.StartDate == rental.EndDate)
        {
            throw new ValidationException("StartDate and EndDate could not be the same");
        }

        if (rental.EndDate < rental.StartDate)
        {
            throw new ValidationException("EndDate cannot be before StartDate");
        }

        if (rental.StartDate < DateTime.UtcNow.AddMinutes(-1))
        {
            throw new ValidationException("StartDate cannot be in the past");
        }
    }
}
