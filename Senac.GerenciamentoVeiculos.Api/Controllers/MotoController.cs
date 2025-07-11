using Microsoft.AspNetCore.Mvc;
using Senac.GerenciamentoVeiculos.Domain.Dtos.Requests.Carro;
using Senac.GerenciamentoVeiculos.Domain.Dtos.Requests.Moto;
using Senac.GerenciamentoVeiculos.Domain.Dtos.Responses;
using Senac.GerenciamentoVeiculos.Domain.Services.Moto;

namespace Senac.GerenciamentoVeiculos.Api.Controllers;

[ApiController]
[Route("moto")]
public class MotoController : Controller
{
    private readonly IMotoService _motoService;

    public MotoController(IMotoService motoService)
    {
        _motoService = motoService;
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
            var erroResponse = new ErroResponse
            {
                Mensagem = ex.Message,
            };
            return NotFound(erroResponse);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar([FromBody] CadastrarMotoRequest cadastrarRequest)
    {
        try
        {
            var cadastrarResponse = await _motoService.Cadastrar(cadastrarRequest);
            return Ok(cadastrarResponse);
        }
        catch (Exception ex)
        {
            var erroResponse = new ErroResponse
            {
                Mensagem = ex.Message,
            };
            return BadRequest(erroResponse);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarPorId([FromBody] long id)
    {
        try
        {
            await _motoService.DeletarPorId(id);
            return Ok();
        }
        catch (Exception ex)
        {
            var erroResponse = new ErroResponse
            {
                Mensagem = ex.Message,
            };
            return BadRequest(erroResponse);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarPorId([FromRoute] long id, [FromBody] AtualizarMotoRequest atualizarMotoRequest)
    {
        try
        {
            await _motoService.AtualizarPorId(id, atualizarMotoRequest);
            return Ok();
        }
        catch (Exception ex)
        {
            var erroResponse = new ErroResponse
            {
                Mensagem = ex.Message,
            };
            return BadRequest(erroResponse);
        }
    }
}
