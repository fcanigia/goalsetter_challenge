using FluentAssertions;
using GoalsetterChallenge.AppCore.Services;
using GoalsetterChallenge.Domain.Abstract;
using GoalsetterChallenge.Domain.Entities;
using GoalsetterChallenge.Infrastructure.Context;
using GoalsetterChallenge.Tools.CustomExceptions;
using GoalsetterChallenge.WebApi.Dto;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace VehicleRental.UnitTests;

public class RentalService_Should
{
    private readonly RentalDbContext _context;
    private readonly Mock<IVehicleService> _vehicleServiceMock;
    private readonly Mock<IClientService> _clientServiceMock;
    private readonly Vehicle _vehicle1 = new() { Id = 1, DailyPrice = 10.01, Model = "Golf", Brand = "Volkswagen", Year = 2023, Type = "Car" };
    private readonly Client _client1 = new() { Id = 1, FirstName = "John", LastName = "Doe", EmailAddress = "JohnDoe@gmail.com", PhoneNumber = "+54 9 11 3232 1212" };

    private readonly Vehicle _vehicleRemoved = new() { Id = 1, DailyPrice = 10.01, Model = "Golf", Brand = "Volkswagen", Year = 2023, Type = "Car", IsRemoved = true };
    private readonly Client _clientRemoved = new() { Id = 1, FirstName = "John", LastName = "Doe", EmailAddress = "JohnDoe@gmail.com", PhoneNumber = "+54 9 11 3232 1212", IsRemoved = true };

    public RentalService_Should()
    {
        var dbContextOptions = new DbContextOptionsBuilder<RentalDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _context = new RentalDbContext(dbContextOptions);
        _vehicleServiceMock = new Mock<IVehicleService>();
        _clientServiceMock = new Mock<IClientService>();
    }

    private void SetupVehicleAndClientMocks(RentalInDto rentalDto)
    {
        _vehicleServiceMock.Setup(service => service.GetById(rentalDto.VehicleId))
                           .ReturnsAsync(_vehicle1);

        _clientServiceMock.Setup(service => service.GetById(rentalDto.ClientId))
                          .ReturnsAsync(_client1);
    }

    private void SetupRemovedVehicleAndClientMocks(RentalInDto rentalDto)
    {
        _vehicleServiceMock.Setup(service => service.GetById(rentalDto.VehicleId))
                           .ReturnsAsync(_vehicleRemoved);

        _clientServiceMock.Setup(service => service.GetById(rentalDto.ClientId))
                          .ReturnsAsync(_client1);
    }

    private void SetupVehicleAndRemovedClientMocks(RentalInDto rentalDto)
    {
        _vehicleServiceMock.Setup(service => service.GetById(rentalDto.VehicleId))
                           .ReturnsAsync(_vehicle1);

        _clientServiceMock.Setup(service => service.GetById(rentalDto.ClientId))
                          .ReturnsAsync(_clientRemoved);
    }

    [Fact]
    public async void CreateRental_ReturnsRental_WhenDataIsValid()
    {
        // Arrange
        var rentalDto = new RentalInDto
        {
            VehicleId = 1,
            ClientId = 1,
            StartDate = DateTime.UtcNow.AddDays(1),
            EndDate = DateTime.UtcNow.AddDays(5)
        };

        SetupVehicleAndClientMocks(rentalDto);

        var rentalService = new RentalService(_context, _clientServiceMock.Object, _vehicleServiceMock.Object);

        // Act
        var result = await rentalService.Create(rentalDto);

        // Assert
        result.Should().NotBeNull();
        result.ClientId.Should().Be(rentalDto.ClientId);
        result.VehicleId.Should().Be(rentalDto.VehicleId);
        result.StartDate.Should().Be(rentalDto.StartDate);
        result.EndDate.Should().Be(rentalDto.EndDate);
        result.Price.Should().BeGreaterThan(0);
    }

    [Fact]
    public async void CreateRental_ReturnsError_WhenDatesAreEqual()
    {
        // Arrange
        var rentalDto = new RentalInDto
        {
            VehicleId = 1,
            ClientId = 1,
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow
        };

        SetupVehicleAndClientMocks(rentalDto);

        var rentalService = new RentalService(_context, _clientServiceMock.Object, _vehicleServiceMock.Object);

        // Act
        Func<Task> action = async () => await rentalService.Create(rentalDto);

        // Assert
        await action.Should().ThrowAsync<ValidationException>()
            .WithMessage("StartDate and EndDate could not be the same");
    }

    [Fact]
    public async void CreateRental_ReturnsError_WhenDateInThePast()
    {
        // Arrange
        var rentalDto = new RentalInDto
        {
            VehicleId = 1,
            ClientId = 1,
            StartDate = DateTime.UtcNow.AddDays(-1),
            EndDate = DateTime.UtcNow
        };

        SetupVehicleAndClientMocks(rentalDto);

        var rentalService = new RentalService(_context, _clientServiceMock.Object, _vehicleServiceMock.Object);

        // Act
        Func<Task> action = async () => await rentalService.Create(rentalDto);

        // Assert
        await action.Should().ThrowAsync<ValidationException>()
            .WithMessage("StartDate cannot be in the past");
    }

    [Fact]
    public async void CreateRental_ReturnsError_WhenEndOlderThanStart()
    {
        // Arrange
        var rentalDto = new RentalInDto
        {
            VehicleId = 1,
            ClientId = 1,
            StartDate = DateTime.UtcNow.AddDays(5),
            EndDate = DateTime.UtcNow.AddDays(3)
        };

        SetupVehicleAndClientMocks(rentalDto);

        var rentalService = new RentalService(_context, _clientServiceMock.Object, _vehicleServiceMock.Object);

        // Act
        Func<Task> action = async () => await rentalService.Create(rentalDto);

        // Assert
        await action.Should().ThrowAsync<ValidationException>()
            .WithMessage("EndDate cannot be before StartDate");
    }

    [Fact]
    public async void CreateRental_ReturnsError_WhenVehicleRemoved()
    {
        // Arrange
        var rentalDto = new RentalInDto
        {
            VehicleId = 1,
            ClientId = 1,
            StartDate = DateTime.UtcNow.AddDays(1),
            EndDate = DateTime.UtcNow.AddDays(3)
        };

        SetupRemovedVehicleAndClientMocks(rentalDto);

        var rentalService = new RentalService(_context, _clientServiceMock.Object, _vehicleServiceMock.Object);

        // Act
        Func<Task> action = async () => await rentalService.Create(rentalDto);

        // Assert
        await action.Should().ThrowAsync<ValidationException>()
            .WithMessage("Vehicle with Id 1 was removed from the Rental and cannot be selected");
    }

    [Fact]
    public async void CreateRental_ReturnsError_WhenClientRemoved()
    {
        // Arrange
        var rentalDto = new RentalInDto
        {
            VehicleId = 1,
            ClientId = 1,
            StartDate = DateTime.UtcNow.AddDays(1),
            EndDate = DateTime.UtcNow.AddDays(3)
        };

        SetupVehicleAndRemovedClientMocks(rentalDto);

        var rentalService = new RentalService(_context, _clientServiceMock.Object, _vehicleServiceMock.Object);

        // Act
        Func<Task> action = async () => await rentalService.Create(rentalDto);

        // Assert
        await action.Should().ThrowAsync<ValidationException>()
            .WithMessage("Client with Id 1 was removed from the Rental and cannot rent new cars");
    }
}