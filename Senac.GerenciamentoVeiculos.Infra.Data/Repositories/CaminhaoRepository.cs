using Dapper;
using Senac.GerenciamentoVeiculos.Domain.Models.Veiculos;
using Senac.GerenciamentoVeiculos.Domain.Repositories;
using Senac.GerenciamentoVeiculos.Infra.Data.DataBaseConfiguration;

namespace Senac.GerenciamentoVeiculos.Infra.Data.Repositories;

// Responsavel por conectar com o banco de dados e retornar os dados

public class CaminhaoRepository : ICaminhaoRepository
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
                    t.Id AS TipoCombustivelCaminhao,
                    c.CapacidadeCargaToneladas,
                    c.QuantidadeEixos
                FROM 
                    caminhao c
                INNER JOIN 
                    TipoCombustivelCaminhao t ON t.Id = c.TipoCombustivelId
                WHERE
                    c.id = @Id
            ",
            new
            { Id = id }
        );
    }

    public async Task<long> Cadastrar(Caminhao caminhao)
    {
        return await _connectionFactory.CreateConnection()
            .QueryFirstOrDefaultAsync(
            @"
                INSERT INTO caminhao
                (
                    nome, 
                    marca, 
                    placa, 
                    cor,    
                    anoFabricacao, 
                    tipoCombustivelId,
                    capacidadeCargaToneladas,
                    quantidadeEixos
                )
                OUTPUT INSERTED.id
                VALUES
                (
                    @Nome, 
                    @Marca, 
                    @Placa, 
                    @Cor, 
                    @AnoFabricacao, 
                    @TipoCombustivelCaminhao,
                    @CapacidadeCargaToneladas,
                    @QuantidadeEixos
                )
            ",
            caminhao);
    }

    public async Task DeletarPorId(long id)
    {
        await _connectionFactory.CreateConnection()
            .QueryFirstOrDefaultAsync(
            @"
                DELETE 
                FROM caminhao
                WHERE id = @Id
            ",
            new { Id = id }
            );
    }

    public async Task AtualizarPorId(Caminhao caminhao)
    {
        await _connectionFactory.CreateConnection()
            .QueryFirstOrDefaultAsync(
            @"
                UPDATE 
                    caminhao
                SET 
                    placa = @Placa,
                    cor = @Cor, 
                    tipoCombustivelId = @TipoCombustivelCaminhao,
                    capacidadeCargaToneladas = @CapacidadeCargaToneladas,
                    quantidadeEixos = @QuantidadeEixos
                WHERE 
                    id = @Id
            ",
            caminhao);
    }
}
