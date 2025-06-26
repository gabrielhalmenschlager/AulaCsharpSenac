using Senac.GerenciamentoVeiculos.Domain.Models;

namespace Senac.GerenciamentoVeiculos.Domain.Repositories
{
    public interface ICarroRepository
    {
        Task<IEnumerable<Carro>> ObterTodos();
    }
}