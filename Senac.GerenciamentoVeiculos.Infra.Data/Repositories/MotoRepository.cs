using Dapper;
using Senac.GerenciamentoVeiculos.Domain.Models;
using Senac.GerenciamentoVeiculos.Domain.Repositories;
using Senac.GerenciamentoVeiculos.Infra.Data.DataBaseConfiguration;

namespace Senac.GerenciamentoVeiculos.Infra.Data.Repositories;

// Responsavel por conectar com o banco de dados e retornar os dados
public class MotoRepository : IMotoRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public MotoRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<Moto>> ObterTodos()
    {
        return await _connectionFactory.CreateConnection()
            .QueryAsync<Moto>(
            @"
                SELECT 
                    id, 
                    nome
                FROM moto"
            );
    }

    public async Task<Moto> ObterDetalhadoPorId(long id)
    {
        return await _connectionFactory.CreateConnection()
            .QueryFirstOrDefaultAsync<Moto>(
            @"
            SELECT 
                m.id, 
                m.nome, 
                m.marca, 
                m.placa, 
                m.cor, 
                m.anoFabricacao,
                t.Id AS TipoCombustivelMoto
            FROM 
                moto m
            INNER JOIN 
                TipoCombustivelMoto t ON t.Id = m.TipoCombustivelId
            WHERE
                m.id = @Id",
            new
            {
                Id = id
            }
        );
    }

    public async Task<long> Cadastrar(Moto moto)
    {
        return await _connectionFactory.CreateConnection()
            .QueryFirstOrDefaultAsync<long>(
            @"
                INSERT INTO moto
                (
                    nome, 
                    marca, 
                    placa, 
                    cor, 
                    anoFabricacao, 
                    TipoCombustivelId
                )
                OUTPUT INSERTED.id                
                VALUES
                (
                    @Nome, 
                    @Marca, 
                    @Placa, 
                    @Cor, 
                    @AnoFabricacao, 
                    @TipoCombustivelMoto
                )
            ",
            moto);
    }

    public async Task DeletarPorId(long id)
    {
        await _connectionFactory.CreateConnection()
            .QueryFirstOrDefaultAsync(
            @"
                DELETE 
                FROM moto
                WHERE id = @Id
            ",
            new { Id = id }
            );
    }

    public async Task AtualizarPorId(Moto moto)
    {
        await _connectionFactory.CreateConnection()
            .QueryFirstOrDefaultAsync(
            @"
                UPDATE 
                    moto
                SET 
                    placa = @Placa,
                    cor = @Cor, 
                    tipoCombustivelId = @TipoCombustivelMoto
                WHERE 
                    id = @Id
            ",
            moto);
    }
}