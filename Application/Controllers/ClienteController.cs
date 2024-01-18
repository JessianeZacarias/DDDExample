using Domain.Commands;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService; 
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }           

        [HttpPost]
        [Route("CadastroClientes")]
        public async Task<IActionResult> CadastroAsync(ClientesCommand command)
        {
            return Ok(await _clienteService.CadastroAsync(command));
        }
        [HttpGet]
        [Route("ClientesEstado")]
        public async Task<IActionResult> GetUfAsync(string Estado)
        {
            return Ok(await _clienteService.GetUfAsync(Estado));
        }
    }
}
