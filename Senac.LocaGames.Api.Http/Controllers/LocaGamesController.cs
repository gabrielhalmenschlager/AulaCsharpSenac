using Microsoft.AspNetCore.Mvc;
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
        return Ok();
    }

    [HttpGet("/{id}/game")]
    public async Task<IActionResult> GetDetailedGameById([FromRoute] long id)
    {
        return Ok();
    }

    [HttpPut("/add/game")]
    public IActionResult AddGame([FromBody] AddGameRequest addGameRequest)
    {
        return Ok();
    }

    [HttpPut("/game/{id}/update")]
    public async Task<IActionResult> UpdateGame([FromRoute] long id, [FromBody] UpdateGameRequest updateGameRequest)
    {
        return Ok();
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