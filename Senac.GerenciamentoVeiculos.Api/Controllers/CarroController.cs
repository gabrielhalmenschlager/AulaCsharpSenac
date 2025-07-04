using Microsoft.AspNetCore.Mvc;
using Senac.GerenciamentoVeiculos.Domain.Dtos.Requests.Carro;
using Senac.GerenciamentoVeiculos.Domain.Dtos.Responses;
using Senac.GerenciamentoVeiculos.Domain.Services;

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
        try
        {
            var carroDetalhadoResponse = await _carroService.ObterDetalhadoPorId(id);

            return Ok(carroDetalhadoResponse);
        }
        catch (Exception ex)
        {
            var response = new ErroResponse 
            {
                Mensagem = ex.Message,
            };
            return NotFound(response);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar([FromBody] CadastrarCarroRequest cadastrarRequest)
    {
        try
        {
            var cadastrarResponse = await _carroService.Cadastrar(cadastrarRequest);
            return Ok(cadastrarResponse);
        }
        catch (Exception ex)
        {
            var response = new ErroResponse
            {
                Mensagem = ex.Message,
            };
            return NotFound(response);
        }
    }
}
