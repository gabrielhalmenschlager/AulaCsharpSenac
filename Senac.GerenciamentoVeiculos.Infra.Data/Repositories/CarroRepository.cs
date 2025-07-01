using Dapper;
using Senac.GerenciamentoVeiculos.Domain.Models;
using Senac.GerenciamentoVeiculos.Domain.Repositories;
using Senac.GerenciamentoVeiculos.Infra.Data.DataBaseConfiguration;

namespace Senac.GerenciamentoVeiculos.Infra.Data.Repositories;

// Responsavel por conectar com o banco de dados e retornar os dados
public class CarroRepository : ICarroRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public CarroRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<Carro>> ObterTodos()
    {
        return await _connectionFactory.CreateConnection()
            .QueryAsync<Carro>(
            @"
                SELECT 
                    id, 
                    nome
                FROM carro"
            );  
    }

    public async Task<Carro> ObterDetalhadoPorId(long id)
    {
        return await _connectionFactory.CreateConnection()
            .QueryFirstOrDefaultAsync<Carro>(
            @"
            SELECT 
                id, 
                nome, 
                marca, 
                placa, 
                cor, 
                anoFabricacao,
                tipoCombustivelId
            FROM 
                carro
            WHERE
                id = @Id",
            new
            { 
                Id = id 
            }
        );
    }
}