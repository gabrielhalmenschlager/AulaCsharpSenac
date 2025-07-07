using Senac.GerenciamentoVeiculos.Domain.Dtos.Requests.Caminhao;
using Senac.GerenciamentoVeiculos.Domain.Dtos.Responses.Caminhao;
using Senac.GerenciamentoVeiculos.Domain.Models;
using Senac.GerenciamentoVeiculos.Domain.Repositories;

namespace Senac.GerenciamentoVeiculos.Domain.Services;

public class CaminhaoService : ICaminhaoService
{
    private readonly ICaminhaoRepository _caminhaoRepository;

    public CaminhaoService(ICaminhaoRepository caminhaoRepository)
    {
        _caminhaoRepository = caminhaoRepository;
    }

    public async Task<IEnumerable<ObterTodosCaminhoesResponse>> ObterTodos()
    {
        var caminhoes = await _caminhaoRepository.ObterTodos();

        var caminhoesResponse = caminhoes
            .Select(x => new ObterTodosCaminhoesResponse
            {
                Id = x.Id,
                Nome = x.Nome,
            });

        return caminhoesResponse;
    }

    public async Task<ObterCaminhaoDetalhadoPorIdResponse> ObterDetalhadoPorId(long id)
    {
        var caminhoes = await _caminhaoRepository.ObterDetalhadoPorId(id);

        if (caminhoes == null)
        {
            throw new Exception($"Caminhão com ID {id} não encontrado.");
        }

        var caminhoesResponse = new ObterCaminhaoDetalhadoPorIdResponse
        {
            Id = caminhoes.Id,
            Nome = caminhoes.Nome,
            Marca = caminhoes.Marca,
            Placa = caminhoes.Placa,
            Cor = caminhoes.Cor,
            AnoFabricacao = caminhoes.AnoFabricacao,
            TipoCombustivel = caminhoes.TipoCombustivel.ToString(),
            CapacidadeCargaToneladas = caminhoes.CapacidadeCargaToneladas,
            QuantidadeEixos = caminhoes.QuantidadeEixos
        };
        return caminhoesResponse;
    }

    public async Task<CadastrarCaminhaoResponse> Cadastrar(CadastrarCaminhaoRequest cadastrarRequest)
    {
        bool IsTipoCombustivelValido = Enum.TryParse(cadastrarRequest.TipoCombustivel, ignoreCase: true, out TipoCombustivel tipoCombustivel);
        if (!IsTipoCombustivelValido)
        {
            throw new Exception($"Tipo de combustível '{cadastrarRequest.TipoCombustivel}' inválido.");
        }
        var caminhao = new Caminhao
        {
            Nome = cadastrarRequest.Nome,
            Marca = cadastrarRequest.Marca,
            Placa = cadastrarRequest.Placa,
            Cor = cadastrarRequest.Cor,
            AnoFabricacao = cadastrarRequest.AnoFabricacao,
            TipoCombustivel = tipoCombustivel,
            CapacidadeCargaToneladas = cadastrarRequest.CapacidadeCargaToneladas,
            QuantidadeEixos = cadastrarRequest.QuantidadeEixos
        };

        long idResponse = await _caminhaoRepository.Cadastrar(caminhao);

        var response = new CadastrarCaminhaoResponse
        {
            Id = idResponse,
            Nome = caminhao.Nome,
            Marca = caminhao.Marca,
            Placa = caminhao.Placa,
            Cor = caminhao.Cor,
            AnoFabricacao = caminhao.AnoFabricacao,
            TipoCombustivel = caminhao.TipoCombustivel.ToString()
        };

        return response;
    }

    public async Task DeletarPorId(long id)
    {
        var carros = await _caminhaoRepository.ObterDetalhadoPorId(id);

        if (carros == null)
        {
            throw new Exception($"Não foi possivel deletar o carro com o id {id}");
        }

        await _caminhaoRepository.DeletarPorId(id);
    }
}
