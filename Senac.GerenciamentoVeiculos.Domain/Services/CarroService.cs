using Senac.GerenciamentoVeiculos.Domain.Dtos.Responses.Carro;
using Senac.GerenciamentoVeiculos.Domain.Repositories;
using Senac.GerenciamentoVeiculos.Domain.Dtos.Requests.Carro;
using Senac.GerenciamentoVeiculos.Domain.Models.Combustiveis;
using Senac.GerenciamentoVeiculos.Domain.Models.Veiculos;

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
        var carro = await _carroRepository.ObterTodos();

        var carroResponse = carro
            .Select(x => new ObterTodosCarrosResponse
            {
                Id = x.Id,
                Nome = x.Nome,
            });

        return carroResponse;
    }

    public async Task<ObterCarroDetalhadoPorIdResponse> ObterDetalhadoPorId(long id)
    {
        var carro = await _carroRepository.ObterDetalhadoPorId(id);
        ValidarSeCarroExiste(carro, id);

        var carrosResponse = new ObterCarroDetalhadoPorIdResponse
        {
            Id = carro.Id,
            Nome = carro.Nome,
            Marca = carro.Marca,
            Placa = carro.Placa,
            Cor = carro.Cor,
            AnoFabricacao = carro.AnoFabricacao,
            TipoCombustivelCarro = carro.TipoCombustivelCarro.ToString()
        };
        return carrosResponse;
    }

    public async Task<CadastrarCarroResponse> Cadastrar(CadastrarCarroRequest cadastrarRequest)
    {
        bool isTipoCombustivelValido = Enum.TryParse(cadastrarRequest.TipoCombustivelCarro, ignoreCase: true , out TipoCombustivelCarro tipoCombustivelCarro);
        ValidarTipoCombustivel(isTipoCombustivelValido, cadastrarRequest.TipoCombustivelCarro);

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
        var carro = await _carroRepository.ObterDetalhadoPorId(id);
        ValidarSeCarroExiste(carro, id);

        await _carroRepository.DeletarPorId(id);
    }

    public async Task AtualizarPorId(long id, AtualizarCarroRequest atualizarCarroRequest)
    {
        bool isTipoCombustivelValido = Enum.TryParse(atualizarCarroRequest.TipoCombustivelCarro, ignoreCase: true, out TipoCombustivelCarro tipoCombustivelCarro);
        ValidarTipoCombustivel(isTipoCombustivelValido, atualizarCarroRequest.TipoCombustivelCarro);

        var carro = await _carroRepository.ObterDetalhadoPorId(id);
        ValidarSeCarroExiste(carro, id);

        carro.Placa = atualizarCarroRequest.Placa;
        carro.Cor = atualizarCarroRequest.Cor;
        carro.TipoCombustivelCarro = tipoCombustivelCarro;
    
        await _carroRepository.AtualizarPorId(carro);
    }

    private void ValidarSeCarroExiste(Carro carro, long id)
    {
        if (carro == null)
        {
            throw new Exception($"Carro com ID {id} não encontrado.");
        }
    }

    private void ValidarTipoCombustivel(bool isTipoCombustivelValido, string tipoCombustivelCarro)
    {
        if (!isTipoCombustivelValido)
        {
            throw new Exception($"Tipo de combustível '{tipoCombustivelCarro}' inválido.");
        }
    }
}