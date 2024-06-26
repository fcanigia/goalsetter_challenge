﻿using GoalsetterChallenge.Domain.Abstract;
using GoalsetterChallenge.Domain.Entities;
using GoalsetterChallenge.Infrastructure.Context;
using GoalsetterChallenge.Tools.CustomExceptions;
using Microsoft.EntityFrameworkCore;

namespace GoalsetterChallenge.AppCore.Services;

public class VehicleService : IVehicleService
{
    private readonly RentalDbContext _context;

    public VehicleService(RentalDbContext context)
    {
        _context = context;
    }

    public async Task<List<Vehicle>> GetAll()
    {
        var vehicles = await _context.Vehicles.ToListAsync();

        return vehicles;
    }

    public async Task<Vehicle> GetById(int vehicleId)
    {
        var vehicle = await _context.Vehicles.FindAsync(vehicleId) 
            ?? throw new NotFoundException($"Vehicle with ID {vehicleId} not found.");

        return vehicle;
    }

    public async Task<Vehicle> Add(Vehicle vehicle)
    {
        if (vehicle.DailyPrice <= 0) { throw new ValidationException("Vehicle daily price cannot be 0 or a negative value"); }
            
        _context.Vehicles.Add(vehicle);

        await _context.SaveChangesAsync();

        return vehicle;
    }

    public async Task<bool> Remove(int vehicleId)
    {
        var vehicleToDelete = await GetById(vehicleId);

        if (vehicleToDelete == null) { return false; }

        vehicleToDelete.IsRemoved = true;

        _context.Vehicles.Update(vehicleToDelete);
        await _context.SaveChangesAsync();

        return true;
    }
}
