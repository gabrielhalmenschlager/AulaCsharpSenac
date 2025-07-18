using Senac.LocaGames.Domain.Dtos.Request;
using Senac.LocaGames.Domain.Dtos.Response;
using Senac.LocaGames.Domain.Repositories;
using Senac.LocaGames.Dominio.Models;

namespace Senac.LocaGames.Domain.Services;

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;

    public GameService(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<IEnumerable<GetAllGamesResponse>> GetAllGames()
    {
        var game = await _gameRepository.GetAllGames();
        
        var gameResponse = game
            .Select(g => new GetAllGamesResponse
            {
                Id = g.Id,
                Title = g.Title,
                Available = g.Available,
                Category = g.Category,
                WithdrawalDate = (DateTime)g.WithdrawalDate
            });

        return gameResponse;
    }

    public async Task<GetDetailedGameByIdResponse> GetDetailedGameById(long id)
    {
        var game = await _gameRepository.GetDetailedGameById(id);
        ValidateIfGameExists(game, id);

        var gameResponse = new GetDetailedGameByIdResponse
        {
            Id = game.Id,
            Title = game.Title,
            Description = game.Description,
            Available = game.Available,
            Category = game.Category,
            Responsible = game.Responsible,
            WithdrawalDate = (DateTime)game.WithdrawalDate,
        };

        return gameResponse;
    }

    public async Task<AddGameResponse> AddGame(AddGameRequest addGameRequest)
    {
        bool categoryExists = Enum.TryParse(addGameRequest.Category, ignoreCase: true, out GameCategory categoryGame);
        ValidateIfCategoryExists(categoryExists, addGameRequest.Category);
    
        var game = new Game
        {
            Title = addGameRequest.Title,
            Description = addGameRequest.Description,
            Category = categoryGame,
            Available = true,
            Responsible = null,
            WithdrawalDate = null,
        };

        long idGameResponse = await _gameRepository.AddGame(game);
        
        var gameResponse = new AddGameResponse
        {
            Id = idGameResponse,
        };

        return gameResponse;
    }

    public async Task UpdateGame(long id, UpdateGameRequest updateGameRequest)
    {
        bool categoryExists = Enum.TryParse(updateGameRequest.Category, ignoreCase: true, out GameCategory categoryGame);
        ValidateIfCategoryExists(categoryExists, updateGameRequest.Category);

        var game = await _gameRepository.GetDetailedGameById(id);
        ValidateIfGameExists(game, id);

        game.Title = updateGameRequest.Title;
        game.Description = updateGameRequest.Description;
        game.Category = categoryGame;

        await _gameRepository.UpdateGame(id, game);
    }


    public async Task<RentGameRequest> RentGame(long id, RentGameRequest rentGameRequest)
    {
        var game = await _gameRepository.GetDetailedGameById(id);
        ValidateIfGameExists(game, id);

        if (!game.Available)
        {
            throw new Exception("O jogo já está alugado.");
        }

        game.Available = false;
        game.Responsible = rentGameRequest.Responsible;
        game.WithdrawalDate = DateTime.Now;

        int prazo = game.Category switch
        {
            GameCategory.BRONZE => 9,
            GameCategory.SILVER => 6,
            GameCategory.GOLD => 3,
            _ => throw new Exception("Categoria inválida.")
        };
        await _gameRepository.UpdateGame(game.Id, game);

        return rentGameRequest;
    }


    public async Task ReturnGame(long id)
    {
        var game = await _gameRepository.GetDetailedGameById(id);
        ValidateIfGameExists(game, id);

        if (game.Available)
        {
            throw new Exception("O jogo já está disponível (não está alugado).");
        }

        game.Available = true;
        game.Responsible = null;
        game.WithdrawalDate = null;

        await _gameRepository.UpdateGame(id, game);
    }


    public async Task DeleteGameById(long id)
    {
        var game = await _gameRepository.GetDetailedGameById(id);
        ValidateIfGameExists(game, id);

        await _gameRepository.DeleteGameById(id);
    }

    private void ValidateIfGameExists(Game game, long id)
    {
        if (game == null)
        {
            throw new Exception($"Game with ID {id} not found.");
        }
    }

    private void ValidateIfCategoryExists(bool categoryExists, string categoryGame)
    { 
        if (!categoryExists)
        {
            throw new Exception($"Category {categoryGame} does not exist.");
        }
    }
}