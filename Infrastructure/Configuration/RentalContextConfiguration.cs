using GoalsetterChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoalsetterChallenge.Infrastructure.Configuration;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.Property(e => e.Model).HasMaxLength(50);
        builder.Property(e => e.Brand).HasMaxLength(50);
        builder.Property(e => e.Type).HasMaxLength(50);
    }
}

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.Property(e => e.FirstName).HasMaxLength(100);
        builder.Property(e => e.LastName).HasMaxLength(100);
        builder.Property(e => e.EmailAddress).HasMaxLength(100);
        builder.Property(e => e.PhoneNumber).HasMaxLength(30);
    }
}