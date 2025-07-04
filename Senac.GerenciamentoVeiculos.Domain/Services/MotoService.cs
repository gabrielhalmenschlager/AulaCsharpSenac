using Senac.GerenciamentoVeiculos.Domain.Dtos.Requests.Moto;
using Senac.GerenciamentoVeiculos.Domain.Dtos.Responses.Moto;
using Senac.GerenciamentoVeiculos.Domain.Models;
using Senac.GerenciamentoVeiculos.Domain.Repositories;

namespace Senac.GerenciamentoVeiculos.Domain.Services;

public class MotoService : IMotoService
{
    private readonly IMotoRepository _motoRepository;

    public async Task<IEnumerable<ObterTodasMotosResponse>> ObterTodos()
    {
        var motos = await _motoRepository.ObterTodos();

        var motosResponse = motos
            .Select(x => new ObterTodasMotosResponse
            {
                Id = x.Id,
                Nome = x.Nome,
            });

        return motosResponse;
    }

    public async Task<ObterMotoDetalhadoPorIdResponse> ObterDetalhadoPorId(long id)
    {
        var motos = await _motoRepository.ObterDetalhadoPorId(id);

        if (motos == null)
        {
            throw new Exception($"Carro com ID {id} não encontrado.");
        }

        var motosResponse = new ObterMotoDetalhadoPorIdResponse
        {
            Id = motos.Id,
            Nome = motos.Nome,
            Marca = motos.Marca,
            Placa = motos.Placa,
            Cor = motos.Cor,
            AnoFabricacao = motos.AnoFabricacao,
            TipoCombustivel = motos.TipoCombustivel.ToString()
        };
        return motosResponse;
    }

    public Task<CadastrarMotoResponse> Cadastrar(CadastrarMotoRequest cadastrarRequest)
    {
        bool IsTipoCombustivelValido = Enum.TryParse(cadastrarRequest.TipoCombustivel, out TipoCombustivel tipoCombustivel);
        if (!IsTipoCombustivelValido)
        {
            throw new Exception($"Tipo de combustível '{cadastrarRequest.TipoCombustivel}' inválido.");
        }
        var moto = new Moto
        {
            Nome = cadastrarRequest.Nome,
            Marca = cadastrarRequest.Marca,
            Placa = cadastrarRequest.Placa,
            Cor = cadastrarRequest.Cor,
            AnoFabricacao = cadastrarRequest.AnoFabricacao,
            TipoCombustivel = tipoCombustivel
        };
        return null;
    }
}
