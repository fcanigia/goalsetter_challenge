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
        var rentals = await _context.Set<Rental>()
            .Include(r => r.Vehicle)
            .Include(r => r.Client)
            .ToListAsync();

        return rentals;
    }

    public async Task<Rental> Create(RentalInDto rental)
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

        var vehicleInUseForDatePeriod = await _context.Set<Rental>()
            .Where(r => r.IsRemoved == false
                && r.VehicleId == rental.VehicleId
                && (rental.StartDate >= r.StartDate && rental.StartDate <= r.EndDate
                || rental.EndDate >= r.StartDate && rental.EndDate <= r.EndDate))
            .AnyAsync();

        if (vehicleInUseForDatePeriod)
        {
            throw new ValidationException($"Vehicle with Id {rental.VehicleId} is not available for the selected dates");
        }

        var clientBookedForSamePeriod = await _context.Set<Rental>()
            .Where(r => r.IsRemoved == false
                && r.ClientId == rental.ClientId
                && (rental.StartDate >= r.StartDate && rental.StartDate <= r.EndDate
                || rental.EndDate >= r.StartDate && rental.EndDate <= r.EndDate))
            .AnyAsync();

        // Could specify the error, with the overlaped period as message
        if (clientBookedForSamePeriod)
        {
            throw new ValidationException($"Client with Id {rental.ClientId} has already booked for these dates");
        }

        var newRental = new Rental()
        {
            ClientId = client.Id,
            VehicleId = vehicle.Id,
            StartDate = rental.StartDate,
            EndDate = rental.EndDate,
            Price = GetRentalPrice(rental.StartDate, rental.EndDate, vehicle.DailyPrice)
        };

        _context.Rentals.Add(newRental);

        await _context.SaveChangesAsync();

        return newRental;
    }

    public async Task<bool> Remove(int rentalId)
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

    private static double GetRentalPrice(DateTime startDate, DateTime endDate, double dailyPrice)
    {
        TimeSpan difference = endDate - startDate;
        int daysBetween = difference.Days;

        if (daysBetween == 0) { return dailyPrice; }

        return dailyPrice * daysBetween;
    }

    private static void ValidateDates(RentalInDto rental)
    {
        if (rental.StartDate.Date == rental.EndDate.Date 
            && rental.StartDate.Hour == rental.EndDate.Hour
            && rental.StartDate.Minute == rental.EndDate.Minute
            && rental.StartDate.Second == rental.EndDate.Second)
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
