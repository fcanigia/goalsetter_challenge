namespace GoalsetterChallenge.Domain.Entities;

public class Rental
{
    public int Id { get; set; }
    public Client? Client { get; set; }
    public int ClientId { get; set; }
    public Vehicle? Vehicle { get; set; }
    public int VehicleId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsRemoved { get; set; } = false;
    public double Price { get; set; }
}