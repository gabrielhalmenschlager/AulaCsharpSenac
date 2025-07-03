using Senac.GerenciamentoVeiculos.Domain.Dtos.Requests.Moto;
using Senac.GerenciamentoVeiculos.Domain.Dtos.Responses.Moto;

namespace Senac.GerenciamentoVeiculos.Domain.Services;

public interface IMotoService
{
    Task<IEnumerable<ObterTodosResponse>> ObterTodos();
    Task<ObterDetalhadoPorIdResponse> ObterDetalhadoPorId(long id);
    Task<CadastrarRequest> Cadastrar(CadastrarRequest cadastrarRequest);
}
