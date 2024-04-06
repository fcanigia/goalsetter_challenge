using GoalsetterChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoalsetterChallenge.Infrastructure.Context;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.SeedVehicles();
        modelBuilder.SeedClients();
        modelBuilder.SeedRentals();
    }

    public static void SeedVehicles(this ModelBuilder modelBuilder) 
    {
        modelBuilder.Entity<Vehicle>()
            .HasData(
                new Vehicle() { Id = 1, DailyPrice = 10.01, Model = "Golf", Brand = "Volkswagen", Year = 2023, Type = "Car" },
                new Vehicle() { Id = 2, DailyPrice = 9, Model = "Up", Brand = "Volkswagen", Year = 2023, Type = "Small Car", IsRemoved = true },
                new Vehicle() { Id = 3, DailyPrice = 15, Model = "Nivus", Brand = "Volkswagen", Year = 2023, Type = "Small SUV" },
                new Vehicle() { Id = 4, DailyPrice = 11, Model = "Virtus", Brand = "Volkswagen", Year = 2023, Type = "Car" },
                new Vehicle() { Id = 5, DailyPrice = 11, Model = "Polo", Brand = "Volkswagen", Year = 2023, Type = "Car" },
                new Vehicle() { Id = 6, DailyPrice = 22, Model = "Tiguan", Brand = "Volkswagen", Year = 2023, Type = "SUV" }
            );
    }

    public static void SeedClients(this ModelBuilder modelBuilder) 
    {
        modelBuilder.Entity<Client>()
            .HasData(
                new Client() { Id = 1, FirstName = "John", LastName = "Doe", EmailAddress = "JohnDoe@gmail.com", PhoneNumber = "+54 9 11 3232 1212" },
                new Client() { Id = 2, FirstName = "Juan", LastName = "Doe", EmailAddress = "JuanDoe@gmail.com", PhoneNumber = "+54 9 11 3232 1213" },
                new Client() { Id = 3, FirstName = "Peter", LastName = "Eod", EmailAddress = "PeterEod@gmail.com", PhoneNumber = "+54 9 11 3232 1214" }
            );
    }

    public static void SeedRentals(this ModelBuilder modelBuilder) 
    {
        modelBuilder.Entity<Rental>()
            .HasData(
                new Rental() { Id = 1, ClientId = 1, VehicleId = 1, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(7) },
                new Rental() { Id = 2, ClientId = 2, VehicleId = 6, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(7) },
                new Rental() { Id = 3, ClientId = 3, VehicleId = 3, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(7) }
            );
    }
}
