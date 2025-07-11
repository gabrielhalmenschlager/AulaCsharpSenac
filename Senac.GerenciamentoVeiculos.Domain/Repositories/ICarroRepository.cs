using Senac.GerenciamentoVeiculos.Domain.Models.Veiculos;

namespace Senac.GerenciamentoVeiculos.Domain.Repositories;

public interface ICarroRepository
{
    Task<IEnumerable<Carro>> ObterTodos();
    Task<Carro> ObterDetalhadoPorId(long id);
    Task<long> Cadastrar(Carro carro);
    Task DeletarPorId(long id);
    Task AtualizarPorId(Carro carro);
}