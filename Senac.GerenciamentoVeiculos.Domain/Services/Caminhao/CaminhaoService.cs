using Senac.GerenciamentoVeiculos.Domain.Dtos.Requests.Caminhao;
using Senac.GerenciamentoVeiculos.Domain.Dtos.Requests.Carro;
using Senac.GerenciamentoVeiculos.Domain.Dtos.Responses.Caminhao;
using Senac.GerenciamentoVeiculos.Domain.Repositories;

namespace Senac.GerenciamentoVeiculos.Domain.Services.Caminhao;

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
            TipoCombustivelCaminhao = caminhoes.TipoCombustivelCaminhao.ToString(),
            CapacidadeCargaToneladas = caminhoes.CapacidadeCargaToneladas,
            QuantidadeEixos = caminhoes.QuantidadeEixos
        };
        return caminhoesResponse;
    }

    public async Task<CadastrarCaminhaoResponse> Cadastrar(CadastrarCaminhaoRequest cadastrarRequest)
    {
        bool IsTipoCombustivelValido = Enum.TryParse(cadastrarRequest.TipoCombustivelCaminhao, ignoreCase: true, out TipoCombustivelCaminhao tipoCombustivelCaminhao);
        if (!IsTipoCombustivelValido)
        {
            throw new Exception($"Tipo de combustível '{cadastrarRequest.TipoCombustivelCaminhao}' inválido.");
        }
        var caminhao = new Caminhao
        {
            Nome = cadastrarRequest.Nome,
            Marca = cadastrarRequest.Marca,
            Placa = cadastrarRequest.Placa,
            Cor = cadastrarRequest.Cor,
            AnoFabricacao = cadastrarRequest.AnoFabricacao,
            TipoCombustivelCaminhao = tipoCombustivelCaminhao,
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
            TipoCombustivelCaminhao = caminhao.TipoCombustivelCaminhao.ToString()
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

    public async Task AtualizarPorId(long id, AtualizarCaminhaoRequest atualizarCaminhaoRequest)
    {
        bool IsTipoCombustivelValido = Enum.TryParse(atualizarCaminhaoRequest.TipoCombustivelCaminhao, ignoreCase: true, out TipoCombustivelCaminhao tipoCombustivelCaminhao);
        if (!IsTipoCombustivelValido)
        {
            throw new Exception($"Tipo de combustível '{atualizarCaminhaoRequest.TipoCombustivelCaminhao}' inválido.");
        }

        var caminhao = await _caminhaoRepository.ObterDetalhadoPorId(id);

        if (caminhao == null)
        {
            throw new Exception($"Carro com ID {id} não encontrado.");
        }

        caminhao.Placa = atualizarCaminhaoRequest.Placa;
        caminhao.Cor = atualizarCaminhaoRequest.Cor;
        caminhao.TipoCombustivelCaminhao = tipoCombustivelCaminhao;
        caminhao.CapacidadeCargaToneladas = atualizarCaminhaoRequest.CapacidadeCargaToneladas;
        caminhao.QuantidadeEixos = atualizarCaminhaoRequest.QuantidadeEixos;

        await _caminhaoRepository.AtualizarPorId(caminhao);
    }
}
