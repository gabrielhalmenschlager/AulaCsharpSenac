using Senac.LocaGames.Domain.Repositories;
using Senac.LocaGames.Dominio.Models;

namespace Senac.LocaGames.Infra.Data.Repositories;

public class GameRepository : IGameRepository
{
    public Task<long> AddGame(Game game)
    {
        throw new NotImplementedException();
    }

    public Task DeleteGameById(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Game>> GetAllGames()
    {
        throw new NotImplementedException();
    }

    public Task<Game> GetDetailedGameById(long id)
    {
        throw new NotImplementedException();
    }

    public Task RentGame(Game game)
    {
        throw new NotImplementedException();
    }

    public Task ReturnGame(long id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateGame(long id, Game game)
    {
        throw new NotImplementedException();
    }
}
