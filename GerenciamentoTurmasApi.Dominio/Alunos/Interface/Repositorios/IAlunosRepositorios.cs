using GerenciamentoTurmasApi.Dominio.Alunos.Entidade;

namespace GerenciamentoTurmasApi.Dominio.Alunos.Interface.Repositorios
{
    public interface IAlunosRepositorios
    {
        Task<List<AlunosEntidade>> ListarAsync();
        Task<AlunosEntidade> ObterPorIdAsync(Guid Id);
        Task AdicionarAsync(AlunosEntidade produto);
    }
}
