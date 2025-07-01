using Senac.GerenciamentoVeiculos.Domain.Dtos.Responses.Carro;
using Senac.GerenciamentoVeiculos.Domain.Services;
using Senac.GerenciamentoVeiculos.Domain.Repositories;

namespace Senac.GerenciamentoVeiculos.Domain.Services;

public class CarroService : ICarroService
{
    private readonly ICarroRepository _carroRepository;

    public CarroService(ICarroRepository carroRepository)
    {
        _carroRepository = carroRepository;
    }

    public async Task<IEnumerable<ObterTodosResponse>> ObterTodos()
    {
        var carros = await _carroRepository.ObterTodos();

        var carrosResponse = carros
            .Select(x => new ObterTodosResponse
            {
                Id = x.Id,
                Nome = x.Nome,
            });

        return carrosResponse;
    }

    public async Task<ObterDetalhadoPorIdResponse> ObterDetalhadoPorId(long id)
    {
        var carros = await _carroRepository.ObterDetalhadoPorId(id);

        var carrosResponse = new ObterDetalhadoPorIdResponse
        {
            Id = carros.Id,
            Nome = carros.Nome,
            Marca = carros.Marca,
            Placa = carros.Placa,
            Cor = carros.Cor,
            AnoFabricacao = carros.AnoFabricacao,
            TipoCombustivel = carros.TipoCombustivel,
        };
        return carrosResponse;
    }
}