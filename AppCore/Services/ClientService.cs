using GoalsetterChallenge.Domain.Abstract;
using GoalsetterChallenge.Domain.Entities;
using GoalsetterChallenge.Infrastructure.Context;
using GoalsetterChallenge.Tools.CustomExceptions;
using Microsoft.EntityFrameworkCore;

namespace GoalsetterChallenge.AppCore.Services;

public class ClientService : IClientService
{
    private readonly RentalDbContext _context;

    public ClientService(RentalDbContext context)
    {
        _context = context;
    }

    public async Task<List<Client>> GetAll()
    {
        var clients = await _context.Clients.ToListAsync();

        return clients;
    }

    public async Task<Client> GetById(int clientId)
    {
        var client = await _context.Clients.FindAsync(clientId) 
            ?? throw new NotFoundException($"Client with ID {clientId} not found."); 

        return client;
    }

    public async Task<Client> Add(Client client)
    {
        _context.Clients.Add(client);

        await _context.SaveChangesAsync();

        return client;
    }

    public async Task<bool> Remove(int clientId)
    {
        var clientToDelete = await _context.Clients.FindAsync(clientId);

        if (clientToDelete == null)
        {
            return false;
        }

        clientToDelete.IsRemoved = true;

        _context.Clients.Update(clientToDelete);
        await _context.SaveChangesAsync();

        return true;
    }
}
