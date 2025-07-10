using Senac.GerenciamentoVeiculos.Domain.Dtos.Requests.Carro;
using Senac.GerenciamentoVeiculos.Domain.Dtos.Requests.Moto;
using Senac.GerenciamentoVeiculos.Domain.Dtos.Responses.Moto;
using Senac.GerenciamentoVeiculos.Domain.Models;
using Senac.GerenciamentoVeiculos.Domain.Repositories;

namespace Senac.GerenciamentoVeiculos.Domain.Services;

public class MotoService : IMotoService
{
    private readonly IMotoRepository _motoRepository;

    public MotoService(IMotoRepository motoRepository)
    {
        _motoRepository = motoRepository;
    }

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
            throw new Exception($"Moto com ID {id} não encontrado.");
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

    public async Task<CadastrarMotoResponse> Cadastrar(CadastrarMotoRequest cadastrarRequest)
    {
        bool IsTipoCombustivelValido = Enum.TryParse(cadastrarRequest.TipoCombustivel, out TipoCombustivelCarro tipoCombustivel);
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

        long idResponse = await _motoRepository.Cadastrar(moto);

        var response = new CadastrarMotoResponse
        {
            Id = idResponse,
            Nome = moto.Nome,
            Marca = moto.Marca,
            Placa = moto.Placa,
            Cor = moto.Cor,
            AnoFabricacao = moto.AnoFabricacao,
            TipoCombustivel = moto.TipoCombustivel.ToString()
        };

        return response;
    }
    public async Task DeletarPorId(long id)
    {
        var carros = await _motoRepository.ObterDetalhadoPorId(id);

        if (carros == null)
        {
            throw new Exception($"Não foi possivel deletar o carro com o id {id}");
        }

        await _motoRepository.DeletarPorId(id);
    }

    public async Task AtualizarPorId(long id, AtualizarMotoRequest atualizarMotoRequest)
    {
        bool IsTipoCombustivelValido = Enum.TryParse(atualizarMotoRequest.TipoCombustivel, ignoreCase: true, out TipoCombustivelCarro tipoCombustivel);
        if (!IsTipoCombustivelValido)
        {
            throw new Exception($"Tipo de combustível '{atualizarMotoRequest.TipoCombustivel}' inválido.");
        }

        var moto = await _motoRepository.ObterDetalhadoPorId(id);

        if (moto == null)
        {
            throw new Exception($"Carro com ID {id} não encontrado.");
        }

        moto.Placa = atualizarMotoRequest.Placa;
        moto.Cor = atualizarMotoRequest.Cor;
        moto.TipoCombustivel = tipoCombustivel;

        await _motoRepository.AtualizarPorId(moto);
    }
}
