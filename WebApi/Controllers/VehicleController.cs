using GoalsetterChallenge.Domain.Abstract;
using GoalsetterChallenge.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GoalsetterChallenge.WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class VehicleController : ControllerBase
{
    private readonly IVehicleService _vehicleService;

    public VehicleController(IVehicleService vehicleService)
    {
        _vehicleService = vehicleService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Add(Vehicle vehicle) 
    { 
        var createdVehicle = await _vehicleService.Add(vehicle);

        return new ObjectResult(createdVehicle)
        {
            StatusCode = StatusCodes.Status201Created
        };
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var vehicles = await _vehicleService.GetAll();  

        return Ok(vehicles);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Remove(int vehicleId)
    {
        var result = await _vehicleService.Remove(vehicleId);

        return Ok(result);  
    }
}
