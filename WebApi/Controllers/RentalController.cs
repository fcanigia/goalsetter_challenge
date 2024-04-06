using GoalsetterChallenge.AppCore.Services;
using GoalsetterChallenge.Domain.Entities;
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

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(Rental rental) 
    { 
        var createdRental = await _rentalService.Create(rental);

        return new ObjectResult(createdRental)
        {
            StatusCode = StatusCodes.Status201Created
        };
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var rentals = await _rentalService.GetAll();  

        return Ok(rentals);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Remove(int rentalId)
    {
        var result = await _rentalService.Remove(rentalId);

        return Ok(result);  
    }
}
