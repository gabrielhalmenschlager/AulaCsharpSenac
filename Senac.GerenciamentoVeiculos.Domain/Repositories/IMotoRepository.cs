using Senac.GerenciamentoVeiculos.Domain.Models;

namespace Senac.GerenciamentoVeiculos.Domain.Repositories;

public interface IMotoRepository
{
    Task<IEnumerable<Moto>> ObterTodos();
    Task<Moto> ObterDetalhadoPorId(long id);
}
