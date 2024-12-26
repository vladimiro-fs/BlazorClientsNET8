namespace BlazorClientsNET8.Shared.Interfaces
{
    using BlazorClientsNET8.Shared.Entities;

    public interface IClientRepository
    {
        Task<Client> AddClientAsync(Client client);

        Task<Client> UpdateClientAsync(Client client);

        Task<Client> DeleteClientAsync(int clientId);

        Task<List<Client>> GetAllClientsAsync();

        Task<Client> GetClientByIdAsync(int clientId);
    }
}
