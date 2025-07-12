using Senac.GerenciamentoVeiculos.Domain.Dtos.Requests.Caminhao;
using Senac.GerenciamentoVeiculos.Domain.Dtos.Requests.Carro;
using Senac.GerenciamentoVeiculos.Domain.Dtos.Responses.Caminhao;
using Senac.GerenciamentoVeiculos.Domain.Models.Combustiveis;
using Senac.GerenciamentoVeiculos.Domain.Models.Veiculos;
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
        var caminhao = await _caminhaoRepository.ObterTodos();

        var caminhaoResponse = caminhao
            .Select(x => new ObterTodosCaminhoesResponse
            {
                Id = x.Id,
                Nome = x.Nome,
            });

        return caminhaoResponse;
    }

    public async Task<ObterCaminhaoDetalhadoPorIdResponse> ObterDetalhadoPorId(long id)
    {
        var caminhao = await _caminhaoRepository.ObterDetalhadoPorId(id);
        ValidarSeCaminhaoExiste(caminhao, id);

        var caminhoesResponse = new ObterCaminhaoDetalhadoPorIdResponse
        {
            Id = caminhao.Id,
            Nome = caminhao.Nome,
            Marca = caminhao.Marca,
            Placa = caminhao.Placa,
            Cor = caminhao.Cor,
            AnoFabricacao = caminhao.AnoFabricacao,
            TipoCombustivelCaminhao = caminhao.TipoCombustivelCaminhao.ToString(),
            CapacidadeCargaToneladas = caminhao.CapacidadeCargaToneladas,
            QuantidadeEixos = caminhao.QuantidadeEixos
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
        var caminhao = await _caminhaoRepository.ObterDetalhadoPorId(id);
        ValidarSeCaminhaoExiste(caminhao, id);

        await _caminhaoRepository.DeletarPorId(id);
    }

    public async Task AtualizarPorId(long id, AtualizarCaminhaoRequest atualizarCaminhaoRequest)
    {
        bool isTipoCombustivelValido = Enum.TryParse(atualizarCaminhaoRequest.TipoCombustivelCaminhao, ignoreCase: true, out TipoCombustivelCaminhao tipoCombustivelCaminhao);
        ValidarTipoCombustivel(isTipoCombustivelValido, atualizarCaminhaoRequest.TipoCombustivelCaminhao);

        var caminhao = await _caminhaoRepository.ObterDetalhadoPorId(id);
        ValidarSeCaminhaoExiste(caminhao, id);

        caminhao.Placa = atualizarCaminhaoRequest.Placa;
        caminhao.Cor = atualizarCaminhaoRequest.Cor;
        caminhao.TipoCombustivelCaminhao = tipoCombustivelCaminhao;
        caminhao.CapacidadeCargaToneladas = atualizarCaminhaoRequest.CapacidadeCargaToneladas;
        caminhao.QuantidadeEixos = atualizarCaminhaoRequest.QuantidadeEixos;

        await _caminhaoRepository.AtualizarPorId(caminhao);
    }

    private void ValidarSeCaminhaoExiste(Caminhao caminhao, long id)
    {
        if (caminhao == null)
        {
            throw new Exception($"Caminhao com ID {id} não encontrado.");
        }
    }

    private void ValidarTipoCombustivel(bool isTipoCombustivelValido, string tipoCombustivelCaminhao)
    {
        if (!isTipoCombustivelValido)
        {
            throw new Exception($"Tipo de combustível '{tipoCombustivelCaminhao}' inválido.");
        }
    }
}
