using ApiClientsDDD.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiClientsWEB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]  // This ensures the route is api/clients
    public class ClientsController : ControllerBase
    {
        private readonly IClientAppService _clientAppService;

        public ClientsController(IClientAppService clientAppService)
        {
            _clientAppService = clientAppService;
        }

        // GET: api/clients
        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            var clients = await _clientAppService.GetAllAsync();
            return Ok(clients);
        }

        // GET: api/clients/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientById(Guid id)
        {
            var client = await _clientAppService.GetByIdAsync(id);
            if (client == null)
                return NotFound();

            return Ok(client);
        }

        // POST: api/clients
        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] ClientDTO clientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _clientAppService.AddAsync(clientDto);
            return CreatedAtAction(nameof(GetClientById), new { id = clientDto.Id }, clientDto);
        }

        // PUT: api/clients/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(Guid id, [FromBody] ClientDTO clientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _clientAppService.UpdateAsync(clientDto);
            return NoContent();
        }

        // DELETE: api/clients/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(Guid id)
        {
            await _clientAppService.DeleteAsync(id);
            return NoContent();
        }
    }
}
