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
                    c.id, 
                    c.nome, 
                    c.marca, 
                    c.placa, 
                    c.cor, 
                    c.anoFabricacao,
                    t.Id AS TipoCombustivelCarro
                FROM 
                    carro c
                INNER JOIN 
                    TipoCombustivelCarro t ON t.Id = c.TipoCombustivelId
                WHERE
                    c.id = @Id
            ",
            new
            { Id = id }
        );
    }

    public async Task<long> Cadastrar(Carro carro)
    {
        return await _connectionFactory.CreateConnection()
            .QueryFirstOrDefaultAsync(
            @"
                INSERT INTO carro
                (
                    nome, 
                    marca, 
                    placa, 
                    cor,    
                    anoFabricacao, 
                    tipoCombustivelId
                )
                OUTPUT INSERTED.id
                VALUES
                (
                    @Nome, 
                    @Marca, 
                    @Placa, 
                    @Cor, 
                    @AnoFabricacao, 
                    @TipoCombustivelCarro
                )
            ",
            carro);
    }

    public async Task DeletarPorId(long id)
    {
        await _connectionFactory.CreateConnection()
            .QueryFirstOrDefaultAsync(
            @"
                DELETE 
                FROM carro
                WHERE id = @Id
            ",
            new { Id = id }
            );
    }

    public async Task AtualizarPorId(Carro carro)
    {
        await _connectionFactory.CreateConnection()
            .QueryFirstOrDefaultAsync(
            @"
                UPDATE 
                    carro
                SET 
                    placa = @Placa,
                    cor = @Cor, 
                    tipoCombustivelId = @TipoCombustivelCarro
                WHERE 
                    id = @Id
            ",
            carro);
    }
}