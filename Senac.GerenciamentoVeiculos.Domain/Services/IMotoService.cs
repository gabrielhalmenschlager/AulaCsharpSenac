using Senac.GerenciamentoVeiculos.Domain.Dtos.Requests.Carro;
using Senac.GerenciamentoVeiculos.Domain.Dtos.Requests.Moto;
using Senac.GerenciamentoVeiculos.Domain.Dtos.Responses.Moto;

namespace Senac.GerenciamentoVeiculos.Domain.Services;

public interface IMotoService
{
    Task<IEnumerable<ObterTodasMotosResponse>> ObterTodos();
    Task<ObterMotoDetalhadoPorIdResponse> ObterDetalhadoPorId(long id);
    Task<CadastrarMotoResponse> Cadastrar(CadastrarMotoRequest cadastrarRequest);
    Task DeletarPorId(long id);
    Task AtualizarPorId(long id, AtualizarMotoRequest atualizarMotoRequest);
}
