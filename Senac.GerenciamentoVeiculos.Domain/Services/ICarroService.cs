using Senac.GerenciamentoVeiculos.Domain.Dtos.Requests.Carro;
using Senac.GerenciamentoVeiculos.Domain.Dtos.Responses.Carro;

namespace Senac.GerenciamentoVeiculos.Domain.Services;

public interface ICarroService
{
    Task<IEnumerable<ObterTodosCarrosResponse>> ObterTodos();
    Task<ObterCarroDetalhadoPorIdResponse> ObterDetalhadoPorId(long id);
    Task<CadastrarCarroResponse> Cadastrar(CadastrarCarroRequest cadastrarRequest);
    Task DeletarPorId(long id);
    Task AtualizarPorId(long id, AtualizarCarroRequest atualizarCarroRequest);
}