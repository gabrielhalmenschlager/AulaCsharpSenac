using GerenciamentoTurmasApi.Dominio.Exercicios.Entidade;

namespace GerenciamentoTurmasApi.Dominio.Exercicios.Interface.Repositorios
{
    public interface IExerciciosRepositorios
    {
        Task<List<ExerciciosEntidade>> ListarAsync();
        Task<ExerciciosEntidade> ObterPorIdAsync(Guid Id);
        Task AdicionarAsync(ExerciciosEntidade produto);
    }
}
