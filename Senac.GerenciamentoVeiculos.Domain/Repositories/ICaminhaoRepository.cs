using Senac.GerenciamentoVeiculos.Domain.Models.Veiculos;
using Senac.GerenciamentoVeiculos.Domain.Models.Veiculos.Caminhao;

namespace Senac.GerenciamentoVeiculos.Domain.Repositories;

public interface ICaminhaoRepository
{
    Task<IEnumerable<Caminhao>> ObterTodos();
    Task<Caminhao> ObterDetalhadoPorId(long id);
    Task<long> Cadastrar(Caminhao caminhao);
    Task DeletarPorId(long id);
    Task AtualizarPorId(Caminhao caminhao);

}
