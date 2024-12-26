namespace BlazorClientsNET8.Controllers
{
    using BlazorClientsNET8.Shared.Entities;
    using BlazorClientsNET8.Shared.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;

        public ClientsController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet("Clients")]
        public async Task<ActionResult<List<Client>>> GetAllClients() 
        {
            var clients = await _clientRepository.GetAllClientsAsync();
            return Ok(clients);
        }

        [HttpGet("Client/{id}")]
        public async Task<ActionResult<Client>> GetClient(int id) 
        {
            var client = await _clientRepository.GetClientByIdAsync(id);
            return Ok(client);
        }

        [HttpPost("AddClient")]
        public async Task<ActionResult<Client>> AddClient(Client client) 
        {
            var newClient = await _clientRepository.AddClientAsync(client);
            return Ok(newClient);
        }

        [HttpPut("UpdateClient")]
        public async Task<ActionResult<Client>> UpdateClient(Client client) 
        {
            var clientToUpdate = await _clientRepository.UpdateClientAsync(client);
            return Ok(clientToUpdate);
        }

        [HttpDelete("DeleteClient/{id}")]
        public async Task<ActionResult<Client>> DeleteClient(int id) 
        {
            var client = await _clientRepository.DeleteClientAsync(id);
            return Ok(client);
        }
    }
}
