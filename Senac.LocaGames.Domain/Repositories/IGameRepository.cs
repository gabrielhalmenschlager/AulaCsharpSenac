using Senac.LocaGames.Dominio.Models;

namespace Senac.LocaGames.Domain.Repositories;

public interface IGameRepository
{
    Task<IEnumerable<Game>> GetAllGames();
    Task<Game> GetDetailedGameById(long id);
    Task<long> AddGame(Game game);
    Task UpdateGame(long id, Game game);
    Task RentGame(Game game);
    Task ReturnGame(long id);
    Task DeleteGameById(long id);

}
