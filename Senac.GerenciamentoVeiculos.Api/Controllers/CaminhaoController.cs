using Microsoft.AspNetCore.Mvc;
using Senac.GerenciamentoVeiculos.Domain.Dtos.Requests.Caminhao;
using Senac.GerenciamentoVeiculos.Domain.Dtos.Responses;
using Senac.GerenciamentoVeiculos.Domain.Services;

namespace Senac.GerenciamentoVeiculos.Api.Controllers;

[ApiController]
[Route("caminhao")]
public class CaminhaoController : Controller
{
    private readonly ICaminhaoService _caminhaoService;

    public CaminhaoController(ICaminhaoService caminhaoService)
    {
        _caminhaoService = caminhaoService;
    }

    [HttpGet]
    public async Task<IActionResult> ObterTodos()
    {
        var caminhaoResponse = await _caminhaoService.ObterTodos();

        return Ok(caminhaoResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterDetalhadoPorId([FromRoute] long id)
    {
        try
        {
            var caminhaoDetalhadoResponse = await _caminhaoService.ObterDetalhadoPorId(id);

            return Ok(caminhaoDetalhadoResponse);
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
    public async Task<IActionResult> Cadastrar([FromBody] CadastrarCaminhaoRequest cadastrarRequest)
    {
        try
        {
            var cadastrarResponse = await _caminhaoService.Cadastrar(cadastrarRequest);
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarPorId([FromBody] long id)
    {
        try
        {
            await _caminhaoService.DeletarPorId(id);
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
    public async Task<IActionResult> AtualizarPorId([FromRoute] long id, [FromBody] AtualizarCaminhaoRequest atualizarCaminhaoRequest)
    {
        try
        {
            await _caminhaoService.AtualizarPorId(id, atualizarCaminhaoRequest);
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