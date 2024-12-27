namespace BlazorClientsNET8.Repositories
{
    using BlazorClientsNET8.Context;
    using BlazorClientsNET8.Shared.Interfaces;
    using BlazorClientsNET8.Shared.Entities;
    using Microsoft.EntityFrameworkCore;

    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;

        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ClientEntity> AddClientAsync(ClientEntity client)
        {
            if (client == null)
                return null!;

            var check = await _context.Clients
                .Where(c => c.Name.ToLower()
                .Equals(client.Name.ToLower()))
                .FirstOrDefaultAsync();

            if (check != null)
                return null!;

            var newClient = _context.Clients.Add(client).Entity;
            await _context.SaveChangesAsync();

            return newClient;
        }

        public async Task<ClientEntity> DeleteClientAsync(int clientId)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == clientId);

            if (client == null)
                return null!;

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return client;
        }

        public async Task<List<ClientEntity>> GetAllClientsAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<ClientEntity> GetClientByIdAsync(int clientId)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == clientId);

            if (client == null)
                return null!;

            return client;
        }

        public async Task<ClientEntity> UpdateClientAsync(ClientEntity client)
        {
            var clientToEdit = await _context.Clients.FirstOrDefaultAsync(c => c.Id == client.Id);

            if (clientToEdit == null)
                return null!;

            clientToEdit.Name = client.Name;
            clientToEdit.Email = client.Email;

            await _context.SaveChangesAsync();

            return await _context.Clients.FirstOrDefaultAsync(c => c.Id == clientToEdit.Id)!;
        }
    }
}
