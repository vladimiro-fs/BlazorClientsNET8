namespace BlazorClientsNET8.Client.Services
{
    using System.Net.Http.Json;
    using System.Text.Json;
    using BlazorClientsNET8.Shared.Entities;
    using BlazorClientsNET8.Shared.Interfaces;

    public class ClientService : IClientRepository
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;

        public ClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<ClientEntity> AddClientAsync(ClientEntity client) 
        {
            var newClient = await _httpClient.PostAsJsonAsync("api/Clients/AddClient", client);
            var response = await newClient.Content.ReadFromJsonAsync<ClientEntity>();

            return response!;
        }

        public async Task<ClientEntity> DeleteClientAsync(int clientId) 
        { 
            var client = await _httpClient.DeleteAsync($"api/Clients/DeleteClient/{clientId}");
            var response = await client.Content.ReadFromJsonAsync<ClientEntity>();

            return response!;
        }

        public async Task<List<ClientEntity>> GetAllClientsAsync() 
        {
            var clients = await _httpClient.GetAsync("api/Clients/Clients");
            var response = await clients.Content.ReadFromJsonAsync<List<ClientEntity>>();
            
            return response!;
        }

        public async Task<ClientEntity> GetClientByIdAsync(int clientId) 
        {
            var client = await _httpClient.GetAsync($"api/Clients/Client/{clientId}");
            var response = await client.Content.ReadFromJsonAsync<ClientEntity>();

            return response!;
        }

        public async Task<ClientEntity> UpdateClientAsync(ClientEntity client) 
        {
            var clientToUpdate = await _httpClient.PutAsJsonAsync("api/Clients/UpdateClient", client);
            var response = await clientToUpdate.Content.ReadFromJsonAsync<ClientEntity>();

            return response!;
        }     
    }
}
