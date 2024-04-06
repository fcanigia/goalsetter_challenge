using GoalsetterChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GoalsetterChallenge.Infrastructure.Context;

public class RentalDbContext : DbContext
{
    public RentalDbContext(DbContextOptions<RentalDbContext> options) : base(options) { }

    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Rental> Rentals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<Rental>()
            .HasOne(r => r.Vehicle)
            .WithMany()
            .HasForeignKey(r => r.VehicleId);

        modelBuilder.Entity<Rental>()
            .HasOne(r => r.Client)
            .WithMany()
            .HasForeignKey(r => r.ClientId);

        base.OnModelCreating(modelBuilder);
    }
}
