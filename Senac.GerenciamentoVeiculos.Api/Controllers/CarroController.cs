using Microsoft.AspNetCore.Mvc;
using Senac.GerenciamentoVeiculos.Domain.Services;
using Senac.GerenciamentoVeiculos.Infra.Data.Repositories;

namespace Senac.GerenciamentoVeiculos.Api.Controllers;

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
        var carroResponse = await _carroService.ObterTodos();

        return Ok(carroResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterDetalhadoPorId([FromRoute] long id)
    {
        var carroDetalhadoResponse = await _carroService.ObterDetalhadoPorId(id);

        return Ok(carroDetalhadoResponse);
    }
}
