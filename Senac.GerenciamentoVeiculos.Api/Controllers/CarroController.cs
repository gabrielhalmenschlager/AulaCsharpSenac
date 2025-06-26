using Microsoft.AspNetCore.Mvc;
using Senac.GerenciamentoVeiculos.Domain.Services;
using Senac.GerenciamentoVeiculos.Infra.Data.Repositories;

namespace Senac.GerenciamentoVeiculos.Api.Controllers
{
    [ApiController]
    [Route("carro")]
    public class CarroController : Controller
    {
        private readonly ICarroService _carroService;

        public CarroController(ICarroService carroService)
        {
            _carroService = carroService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var carros = await _carroService.ObterTodos();

            var carroResponse = await _carroService.ObterTodos();

            return Ok(carroResponse);
        }
    }
}
