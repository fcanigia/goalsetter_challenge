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
                new Rental() { Id = 1, ClientId = 1, VehicleId = 1, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(7), Price = 70.07 },
                new Rental() { Id = 2, ClientId = 2, VehicleId = 6, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(7), Price = 154 },
                new Rental() { Id = 3, ClientId = 3, VehicleId = 3, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(7), Price = 105 },
                new Rental() { Id = 4, ClientId = 1, VehicleId = 1, StartDate = DateTime.Parse("2024-05-01"), EndDate = DateTime.Parse("2024-05-10"), Price =  100.10},
                new Rental() { Id = 5, ClientId = 2, VehicleId = 6, StartDate = DateTime.Parse("2024-05-01"), EndDate = DateTime.Parse("2024-05-10"), Price = 220 },
                new Rental() { Id = 6, ClientId = 3, VehicleId = 3, StartDate = DateTime.Parse("2024-05-01"), EndDate = DateTime.Parse("2024-05-10"), Price = 150 },
                new Rental() { Id = 7, ClientId = 1, VehicleId = 1, StartDate = DateTime.Parse("2024-05-12"), EndDate = DateTime.Parse("2024-05-17"), Price = 60.06 },
                new Rental() { Id = 8, ClientId = 2, VehicleId = 6, StartDate = DateTime.Parse("2024-05-11"), EndDate = DateTime.Parse("2024-05-18"), Price = 176 },
                new Rental() { Id = 9, ClientId = 3, VehicleId = 3, StartDate = DateTime.Parse("2024-05-13"), EndDate = DateTime.Parse("2024-05-19"), Price = 105 }
            );
    }
}
