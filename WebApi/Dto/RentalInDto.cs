﻿namespace GoalsetterChallenge.WebApi.Dto;

public class RentalInDto
{
    public int ClientId { get; set; }
    public int VehicleId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
