using Senac.GerenciamentoVeiculos.Domain.Dtos.Requests.Caminhao;
using Senac.GerenciamentoVeiculos.Domain.Dtos.Requests.Carro;
using Senac.GerenciamentoVeiculos.Domain.Dtos.Responses.Caminhao;

namespace Senac.GerenciamentoVeiculos.Domain.Services.Caminhao;

public interface ICaminhaoService
{
    Task<IEnumerable<ObterTodosCaminhoesResponse>> ObterTodos();
    Task<ObterCaminhaoDetalhadoPorIdResponse> ObterDetalhadoPorId(long id);
    Task<CadastrarCaminhaoResponse> Cadastrar(CadastrarCaminhaoRequest cadastrarRequest);
    Task DeletarPorId(long id);
    Task AtualizarPorId(long id, AtualizarCaminhaoRequest atualizarCaminhaoRequest);
}
