namespace GoalsetterChallenge.Domain.Entities;

public class Vehicle
{
    public int Id { get; set; }
    public double DailyPrice { get; set; }
    public int Year { get; set; }
    public string Model { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public bool IsRemoved { get; set; } = false;
}
