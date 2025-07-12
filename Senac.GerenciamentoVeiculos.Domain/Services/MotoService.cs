using Senac.GerenciamentoVeiculos.Domain.Dtos.Requests.Moto;
using Senac.GerenciamentoVeiculos.Domain.Dtos.Responses.Moto;
using Senac.GerenciamentoVeiculos.Domain.Models.Combustiveis;
using Senac.GerenciamentoVeiculos.Domain.Models.Veiculos;
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
        var moto = await _motoRepository.ObterDetalhadoPorId(id);
        ValidarSeMotoExiste(moto, id);

        var motosResponse = new ObterMotoDetalhadoPorIdResponse
        {
            Id = moto.Id,
            Nome = moto.Nome,
            Marca = moto.Marca,
            Placa = moto.Placa,
            Cor = moto.Cor,
            AnoFabricacao = moto.AnoFabricacao,
            TipoCombustivelMoto = moto.TipoCombustivelMoto.ToString()
        };
        return motosResponse;
    }

    public async Task<CadastrarMotoResponse> Cadastrar(CadastrarMotoRequest cadastrarRequest)
    {
        bool isTipoCombustivelValido = Enum.TryParse(cadastrarRequest.TipoCombustivelMoto, ignoreCase: true, out TipoCombustivelMoto tipoCombustivelMoto);
        ValidarTipoCombustivel(isTipoCombustivelValido, cadastrarRequest.TipoCombustivelMoto);

        var moto = new Moto
        {
            Nome = cadastrarRequest.Nome,
            Marca = cadastrarRequest.Marca,
            Placa = cadastrarRequest.Placa,
            Cor = cadastrarRequest.Cor,
            AnoFabricacao = cadastrarRequest.AnoFabricacao,
            TipoCombustivelMoto = tipoCombustivelMoto
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
            TipoCombustivelMoto = moto.TipoCombustivelMoto.ToString()
        };

        return response;
    }
    public async Task DeletarPorId(long id)
    {
        var moto = await _motoRepository.ObterDetalhadoPorId(id);
        ValidarSeMotoExiste(moto, id);

        await _motoRepository.DeletarPorId(id);
    }

    public async Task AtualizarPorId(long id, AtualizarMotoRequest atualizarMotoRequest)
    {
        bool isTipoCombustivelValido = Enum.TryParse(atualizarMotoRequest.TipoCombustivelMoto, ignoreCase: true, out TipoCombustivelMoto tipoCombustivelMoto);
        ValidarTipoCombustivel(isTipoCombustivelValido, atualizarMotoRequest.TipoCombustivelMoto);

        var moto = await _motoRepository.ObterDetalhadoPorId(id);
        ValidarSeMotoExiste(moto, id);

        moto.Placa = atualizarMotoRequest.Placa;
        moto.Cor = atualizarMotoRequest.Cor;
        moto.TipoCombustivelMoto = tipoCombustivelMoto;

        await _motoRepository.AtualizarPorId(moto);
    }

    private void ValidarSeMotoExiste(Moto moto, long id)
    {
        if (moto == null)
        {
            throw new Exception($"Moto com ID {id} não encontrado.");
        }
    }

    private void ValidarTipoCombustivel(bool isTipoCombustivelValido, string tipoCombustivelMoto)
    {
        if (!isTipoCombustivelValido)
        {
            throw new Exception($"Tipo de combustível '{tipoCombustivelMoto}' inválido.");
        }
    }
}
