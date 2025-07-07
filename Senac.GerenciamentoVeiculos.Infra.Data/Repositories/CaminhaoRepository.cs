using Dapper;
using Senac.GerenciamentoVeiculos.Domain.Models;
using Senac.GerenciamentoVeiculos.Infra.Data.DataBaseConfiguration;

namespace Senac.GerenciamentoVeiculos.Infra.Data.Repositories;

// Responsavel por conectar com o banco de dados e retornar os dados

public class CaminhaoRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public CaminhaoRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<Caminhao>> ObterTodos()
    {
        return await _connectionFactory.CreateConnection()
            .QueryAsync<Caminhao>(
            @"
                SELECT 
                    id, 
                    nome
                FROM caminhao"
            );
    }

    public async Task<Caminhao> ObterDetalhadoPorId(long id)
    {
        return await _connectionFactory.CreateConnection()
            .QueryFirstOrDefaultAsync<Caminhao>(
            @"
                SELECT 
                    c.id, 
                    c.nome, 
                    c.marca, 
                    c.placa, 
                    c.cor, 
                    c.anoFabricacao,
                    t.Id AS TipoCombustivel
                FROM 
                    carro c
                INNER JOIN 
                    TipoCombustivel t ON t.Id = c.TipoCombustivelId
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
                    @TipoCombustivel
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
}
