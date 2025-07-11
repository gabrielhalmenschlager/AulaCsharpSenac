using Senac.GerenciamentoVeiculos.Domain.Dtos.Responses.Carro;
using Senac.GerenciamentoVeiculos.Domain.Repositories;
using Senac.GerenciamentoVeiculos.Domain.Dtos.Requests.Carro;
using Senac.GerenciamentoVeiculos.Domain.Models.Combustiveis;

namespace Senac.GerenciamentoVeiculos.Domain.Services.Carro;

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
            TipoCombustivelCarro = carros.TipoCombustivelCarro.ToString()
        };
        return carrosResponse;
    }

    public async Task<CadastrarCarroResponse> Cadastrar(CadastrarCarroRequest cadastrarRequest)
    {
        bool IsTipoCombustivelValido = Enum.TryParse(cadastrarRequest.TipoCombustivelCarro, ignoreCase: true , out TipoCombustivelCarro tipoCombustivelCarro);
        if (!IsTipoCombustivelValido)
        {
            throw new Exception($"Tipo de combustível '{cadastrarRequest.TipoCombustivelCarro}' inválido.");
        }
        var carro = new Carro
        {
            Nome = cadastrarRequest.Nome,
            Marca = cadastrarRequest.Marca,
            Placa = cadastrarRequest.Placa,
            Cor = cadastrarRequest.Cor,
            AnoFabricacao = cadastrarRequest.AnoFabricacao,
            TipoCombustivelCarro = tipoCombustivelCarro
        };

        long idResponse = await _carroRepository.Cadastrar(carro);

        var response = new CadastrarCarroResponse
        {
            Id = idResponse,
            Nome = carro.Nome,
            Marca = carro.Marca,
            Placa = carro.Placa,
            Cor = carro.Cor,
            AnoFabricacao = carro.AnoFabricacao,
            TipoCombustivelCarro = carro.TipoCombustivelCarro.ToString()
        };

        return response;
    }

    public async Task DeletarPorId(long id)
    {
        var carros = await _carroRepository.ObterDetalhadoPorId(id);

        if (carros == null)
        {
            throw new Exception($"Não foi possivel deletar o carro com o id {id}");
        }

        await _carroRepository.DeletarPorId(id);
    }

    public async Task AtualizarPorId(long id, AtualizarCarroRequest atualizarCarroRequest)
    {
        bool IsTipoCombustivelValido = Enum.TryParse(atualizarCarroRequest.TipoCombustivelCarro, ignoreCase: true, out TipoCombustivelCarro tipoCombustivelCarro);
        if (!IsTipoCombustivelValido)
        {
            throw new Exception($"Tipo de combustível '{atualizarCarroRequest.TipoCombustivelCarro}' inválido.");
        }

        var carro = await _carroRepository.ObterDetalhadoPorId(id);

        if (carro == null)
        {
            throw new Exception($"Carro com ID {id} não encontrado.");
        }

        carro.Placa = atualizarCarroRequest.Placa;
        carro.Cor = atualizarCarroRequest.Cor;
        carro.TipoCombustivelCarro = tipoCombustivelCarro;
    
        await _carroRepository.AtualizarPorId(carro);
    }
}