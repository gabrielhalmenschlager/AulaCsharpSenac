using Microsoft.AspNetCore.Mvc;
using Senac.LocaGames.Domain.Dtos.Error;
using Senac.LocaGames.Domain.Dtos.Request;
using Senac.LocaGames.Domain.Services;

namespace Senac.GerenciamentoVeiculos.Api.Controllers;

[ApiController]
[Route("game")]
public class LocaGamesController : Controller
{
    private readonly IGameService _gameService;

    public LocaGamesController(IGameService gameService)
    {
        _gameService = gameService;
    }

    [HttpGet("/all/games")]
    public async Task<IActionResult> GetAllGames()
    {
        var gameResponse = await _gameService.GetAllGames();

        return Ok(gameResponse);
    }

    [HttpGet("/{id}/game")]
    public async Task<IActionResult> GetDetailedGameById([FromRoute] long id)
    {
        try
        {
            var carroDetalhadoResponse = await _gameService.GetDetailedGameById(id);

            return Ok(carroDetalhadoResponse);
        }
        catch (Exception ex)
        {
            var response = new ErrorResponse
            {
                Mensagem = ex.Message,
            };
            return NotFound(response);
        }
    }

    [HttpPut("/add/game")]
    public async Task<IActionResult> AddGame([FromBody] AddGameRequest addGameRequest)
    {
        try
        {
            var addResponse = await _gameService.AddGame(addGameRequest);
            return Ok(addResponse);
        }
        catch (Exception ex)
        {
            var response = new ErrorResponse
            {
                Mensagem = ex.Message,
            };
            return NotFound(response);
        }
    }

    [HttpPut("/game/{id}/update")]
    public async Task<IActionResult> UpdateGame([FromRoute] long id, [FromBody] UpdateGameRequest updateGameRequest)
    {
        try
        {
            await _gameService.UpdateGame(id, updateGameRequest);
            return Ok();
        }
        catch (Exception ex)
        {
            var errorResponse = new ErrorResponse
            {
                Mensagem = ex.Message,
            };
            return BadRequest(errorResponse);
        }
    }

    [HttpPut("/game/{id}/rent")]
    public IActionResult RentGame(long id, [FromBody] RentGameRequest rentGameRequest)
    {
        return Ok();
    }

    [HttpPut("/game/{id}/return")]
    public IActionResult ReturnGame(long id)
    {
        return Ok();
    }

    [HttpDelete("/game/{id}/delete")]
    public async Task<IActionResult> DeleteGameById([FromBody] long id)
    {
        return Ok();
    }
}