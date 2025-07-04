using Senac.GerenciamentoVeiculos.Domain.Dtos.Responses.Carro;
using Senac.GerenciamentoVeiculos.Domain.Repositories;
using Senac.GerenciamentoVeiculos.Domain.Dtos.Requests.Carro;
using Senac.GerenciamentoVeiculos.Domain.Models;

namespace Senac.GerenciamentoVeiculos.Domain.Services;

public class CarroService : ICarroService
{
    private readonly ICarroRepository _carroRepository;

    public CarroService(ICarroRepository carroRepository)
    {
        _carroRepository = carroRepository;
    }

    public async Task<IEnumerable<ObterTodosCarrosResponse>> ObterTodos()
    {
        var carros = await _carroRepository.ObterTodos();

        var carrosResponse = carros
            .Select(x => new ObterTodosCarrosResponse
            {
                Id = x.Id,
                Nome = x.Nome,
            });

        return carrosResponse;
    }

    public async Task<ObterCarroDetalhadoPorIdResponse> ObterDetalhadoPorId(long id)
    {
        var carros = await _carroRepository.ObterDetalhadoPorId(id);

        if (carros == null)
        {
            throw new Exception($"Carro com ID {id} não encontrado.");
        }

        var carrosResponse = new ObterCarroDetalhadoPorIdResponse
        {
            Id = carros.Id,
            Nome = carros.Nome,
            Marca = carros.Marca,
            Placa = carros.Placa,
            Cor = carros.Cor,
            AnoFabricacao = carros.AnoFabricacao,
            TipoCombustivel = carros.TipoCombustivel.ToString()
        };
        return carrosResponse;
    }

    public Task<CadastrarCarroResponse> Cadastrar(CadastrarCarroRequest cadastrarRequest)
    {
        bool IsTipoCombustivelValido = Enum.TryParse(cadastrarRequest.TipoCombustivel, out TipoCombustivel tipoCombustivel);
        if (!IsTipoCombustivelValido)
        {
            throw new Exception($"Tipo de combustível '{cadastrarRequest.TipoCombustivel}' inválido.");
        }
        var carro = new Carro
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