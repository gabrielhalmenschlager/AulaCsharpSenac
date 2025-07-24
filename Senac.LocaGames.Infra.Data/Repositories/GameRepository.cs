using Dapper;
using Senac.GerenciamentoVeiculos.Infra.Data.DataBaseConfiguration;
using Senac.LocaGames.Domain.Repositories;
using Senac.LocaGames.Dominio.Models;

namespace Senac.LocaGames.Infra.Data.Repositories;

public class GameRepository : IGameRepository
{

    private readonly IDbConnectionFactory _connectionFactory;

    public GameRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<Game>> GetAllGames()
    {
        return await _connectionFactory.CreateConnection()
            .QueryAsync<Game>(
            @"
            SELECT 
                g.id
                , g.title
                , g.available
                , c.Id AS Category                    
                , g.withdrawalDate
            FROM 
                game g
            INNER JOIN
                GameCategory c ON c.Id = g.CategoryId 
            "
            );
    }

    public async Task<Game> GetDetailedGameById(long id)
    {
        return await _connectionFactory.CreateConnection()
            .QueryFirstOrDefaultAsync<Game>(
            @"
            SELECT 
                g.id
                , g.title
                , g.description
                , g.available
                , c.Id AS Category
                , g.responsible
                , g.withdrawalDate
            FROM 
                game g
            INNER JOIN
                GameCategory c ON c.Id = g.CategoryId   
            WHERE g.id = @Id
            ",
            new { Id = id }
            );
    }

    public async Task<long> AddGame(Game game)
    {
        return await _connectionFactory.CreateConnection()
            .QueryFirstOrDefaultAsync<long>(
            @"
            INSERT INTO game
                (
                  title
                , description
                , available
                , categoryId
                , responsible
                , withdrawalDate
                )
            OUTPUT INSERTED.id
            VALUES
                (  
                  @Title 
                , @Description
                , @Available
                , @Category
                , @Responsible
                , @WithdrawalDate
                )
            ",
            game);
    }

    public async Task UpdateGame(long id, Game game)
    {
        await _connectionFactory.CreateConnection()
            .QueryFirstOrDefaultAsync(
            @"
            UPDATE 
                game
            SET 
                  title = @Title
                , description = @Description
                , categoryId = @Category
            WHERE 
                id = @Id
            ",
            game);
    }

    public async Task RentGame(Game game)
    {
        await _connectionFactory.CreateConnection()
            .QueryFirstOrDefaultAsync(
            @"
            UPDATE game
            SET 
                  available = 0
                , responsible = @Responsible
                , withdrawalDate = @WithdrawalDate
            WHERE 
                id = @Id
            ",
            game);
    }

    public async Task ReturnGame(long id)
    {
        await _connectionFactory.CreateConnection()
            .ExecuteAsync(
            @"
            UPDATE game
            SET 
                  available = 1
                , responsible = NULL
                , withdrawalDate = NULL
            WHERE id = @Id
            ", 
            new { Id = id }
            );
    }

    public async Task DeleteGameById(long id)
    {
        await _connectionFactory.CreateConnection()
            .QueryFirstOrDefaultAsync(
            @"
            DELETE FROM game
            WHERE id = @Id
            ",
            new { Id = id }
            );
    }
}
