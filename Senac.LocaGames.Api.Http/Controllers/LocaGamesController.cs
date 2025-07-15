using Microsoft.AspNetCore.Mvc;
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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetailedGameById([FromRoute] long id)
    {
        return Ok();
    }


    [HttpGet]
    public async Task<IActionResult> GetAllGames()
    {
        return Ok();
    }

}