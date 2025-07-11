using Senac.GerenciamentoVeiculos.Domain.Models.Veiculos;

namespace Senac.GerenciamentoVeiculos.Domain.Repositories;

public interface IMotoRepository
{
    Task<IEnumerable<Moto>> ObterTodos();
    Task<Moto> ObterDetalhadoPorId(long id);
    Task<long> Cadastrar(Moto moto);
    Task DeletarPorId(long id);
    Task AtualizarPorId(Moto moto);
}
