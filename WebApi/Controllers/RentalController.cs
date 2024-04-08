using GoalsetterChallenge.AppCore.Services;
using GoalsetterChallenge.Domain.Entities;
using GoalsetterChallenge.WebApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GoalsetterChallenge.WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class RentalController : ControllerBase
{
    private readonly IRentalService _rentalService;

    public RentalController(IRentalService rentalService )
    {
        _rentalService = rentalService;
    }

    [HttpPost(Name = "Creates a new rental")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(RentalInDto rentalIn) 
    { 
        var createdRental = await _rentalService.Create(rentalIn);

        return new ObjectResult(createdRental)
        {
            StatusCode = StatusCodes.Status201Created
        };
    }

    [HttpGet(Name = "Get all rentals")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var rentals = await _rentalService.GetAll();  

        return Ok(rentals);
    }

    [HttpDelete(Name = "Removes a rental")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Remove(int rentalId)
    {
        var result = await _rentalService.Remove(rentalId);

        return Ok(result);  
    }
}
