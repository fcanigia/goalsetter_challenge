using GoalsetterChallenge.Domain.Entities;

namespace GoalsetterChallenge.Domain.Abstract;
public interface IClientService
{
    Task<Client> Add(Client client);
    Task<List<Client>> GetAll();
    Task<bool> Remove(int clientId);
}