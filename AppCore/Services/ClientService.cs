using GoalsetterChallenge.Domain.Abstract;
using GoalsetterChallenge.Domain.Entities;
using GoalsetterChallenge.Infrastructure.Context;
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

    public async Task<Client> Add(Client client)
    {
        try
        {
            _context.Clients.Add(client);

            await _context.SaveChangesAsync();

            return client;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<bool> Remove(int clientId)
    {
        try
        {
            var clientToDelete = await _context.Clients.FindAsync(clientId);

            if (clientToDelete == null)
            {
                return false;
            }

            _context.Clients.Remove(clientToDelete);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception)
        {

            throw;
        }
    }
}
