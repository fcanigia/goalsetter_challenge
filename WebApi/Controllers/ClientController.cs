using GoalsetterChallenge.Domain.Abstract;
using GoalsetterChallenge.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GoalsetterChallenge.WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpPost(Name = "Create new client")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Add(Client client) 
    { 
        var createdClient = await _clientService.Add(client);

        return new ObjectResult(createdClient)
        {
            StatusCode = StatusCodes.Status201Created
        };
    }

    [HttpGet(Name = "Get all clients")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var clients = await _clientService.GetAll();  

        return Ok(clients);
    }

    [HttpDelete(Name = "Remove a client")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Remove(int clientId)
    {
        var result = await _clientService.Remove(clientId);

        return Ok(result);  
    }
}
