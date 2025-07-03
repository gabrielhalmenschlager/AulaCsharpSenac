using Senac.GerenciamentoVeiculos.Domain.Dtos.Requests.Carro;
using Senac.GerenciamentoVeiculos.Domain.Dtos.Responses.Carro;

namespace Senac.GerenciamentoVeiculos.Domain.Services;

public interface ICarroService
{
    Task<IEnumerable<ObterTodosResponse>> ObterTodos();
    Task<ObterDetalhadoPorIdResponse> ObterDetalhadoPorId(long id);
    Task<CadastrarResponse> Cadastrar(CadastrarRequest cadastrarRequest);
}