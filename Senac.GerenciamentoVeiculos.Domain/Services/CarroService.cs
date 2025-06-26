using Senac.GerenciamentoVeiculos.Domain.Dtos.Responses.Carro;
using Senac.GerenciamentoVeiculos.Domain.Services;
using Senac.GerenciamentoVeiculos.Domain.Repositories;

namespace Senac.GerenciamentoVeiculos.Domain.Services
{
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

            var carrosResponse = carros.Select(x => new ObterTodosResponse 
            {
                Id = x.Id,
                Nome = x.Nome,
                Marca = x.Marca,
                Placa = x.Placa,
                Cor = x.Cor,
                AnoFabricacao = x.AnoFabricacao,
                TipoCombustivel = x.TipoCombustivel               
            });

            return carrosResponse;
        }
    }
}