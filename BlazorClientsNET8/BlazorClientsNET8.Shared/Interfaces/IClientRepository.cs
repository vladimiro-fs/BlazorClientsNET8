namespace BlazorClientsNET8.Shared.Interfaces
{
    using BlazorClientsNET8.Shared.Entities;

    public interface IClientRepository
    {
        Task<ClientEntity> AddClientAsync(ClientEntity client);

        Task<ClientEntity> UpdateClientAsync(ClientEntity client);

        Task<ClientEntity> DeleteClientAsync(int clientId);

        Task<List<ClientEntity>> GetAllClientsAsync();

        Task<ClientEntity> GetClientByIdAsync(int clientId);
    }
}
