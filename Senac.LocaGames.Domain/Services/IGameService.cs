using Senac.LocaGames.Domain.Dtos.Request;
using Senac.LocaGames.Domain.Dtos.Response;

namespace Senac.LocaGames.Domain.Services;

public interface IGameService
{
    Task<IEnumerable<GetAllGamesResponse>> GetAllGames();
    Task<GetDetailedGameByIdResponse> GetDetailedGameById(long id);
    Task<AddGameResponse> AddGame(AddGameRequest addGameRequest);
    Task UpdateGame(long id, UpdateGameRequest updateGameRequest);
    Task<RentGameRequest> RentGame(long id, RentGameRequest rentGameRequest);
    Task ReturnGame(long id);
    Task DeleteGameById(long id);
}
