﻿using GoalsetterChallenge.Domain.Abstract;
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

            double rentalPrice;

            TimeSpan difference = rental.EndDate - rental.StartDate;
            int daysBetween = difference.Days;

            if (daysBetween == 0) { rentalPrice = vehicle.DailyPrice; }

            rentalPrice = vehicle.DailyPrice * daysBetween;

            var newRental = new Rental()
            {
                ClientId = client.Id,
                VehicleId = vehicle.Id,
                StartDate = rental.StartDate,
                EndDate = rental.EndDate,
                Price = rentalPrice
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
