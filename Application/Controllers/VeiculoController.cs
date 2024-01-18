using Domain.Commands;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.Enums;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoService _veiculoService;
        public VeiculoController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        [HttpPost]
        [Route("CadastrarVeiculo")]
        public async Task<IActionResult> PostAsy([FromBody] VeiculoCommand command)
        {
            return Ok(await _veiculoService.PostAsync(command));
        }

        [HttpGet]
        [Route("VeiculosDisponíveis")]
        public async Task<IActionResult> GetByIdAsync(bool Alugado) 
        { 
            return Ok(await _veiculoService.GetByIdAsync(Alugado));

        }

    }
}
