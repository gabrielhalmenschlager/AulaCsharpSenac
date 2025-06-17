using GerenciamentoTurmasApi.Dominio.Turmas.Entidade;

namespace GerenciamentoTurmasApi.Dominio.Turmas.Interface.Repositorios
{
    public interface ITurmasRepositorios
    {
        Task<List<TurmasEntidade>> ListarAsync();
        Task<TurmasEntidade> ObterPorIdAsync(Guid Id);
        Task AdicionarAsync(TurmasEntidade produto);
    }
}
