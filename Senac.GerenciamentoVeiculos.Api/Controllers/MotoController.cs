using Microsoft.AspNetCore.Mvc;
using Senac.GerenciamentoVeiculos.Domain.Dtos.Requests.Moto;
using Senac.GerenciamentoVeiculos.Domain.Dtos.Responses;
using Senac.GerenciamentoVeiculos.Domain.Services;
using Senac.GerenciamentoVeiculos.Infra.Data.Repositories;

namespace Senac.GerenciamentoVeiculos.Api.Controllers;

[ApiController]
[Route("moto")]
public class MotoController : Controller
{
    private readonly IMotoService _motoService;

    public MotoController(IMotoService motoService)
    {
        motoService = motoService;
    }

    [HttpGet]
    public async Task<IActionResult> ObterTodos()
    {
        var motoResponse = await _motoService.ObterTodos();

        return Ok(motoResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterDetalhadoPorId([FromRoute] long id)
    {
        try
        {
            var motoDetalhadoResponse = await _motoService.ObterDetalhadoPorId(id);

            return Ok(motoDetalhadoResponse);
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
    public async Task<IActionResult> Cadastrar([FromBody] CadastrarRequest cadastrarRequest)
    {
        try
        {
            var cadastrarResponse = await _motoService.Cadastrar(cadastrarRequest);
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
