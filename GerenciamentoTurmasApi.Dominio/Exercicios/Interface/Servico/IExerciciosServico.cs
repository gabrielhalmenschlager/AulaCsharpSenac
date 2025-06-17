using GerenciamentoTurmasApi.Dominio.Exercicios.Entidade;

namespace GerenciamentoTurmasApi.Dominio.Exercicios.Interface.Servico
{
    public interface IExerciciosServico
    {
        ExerciciosEntidade BuscarPorId(Guid id);
        List<ExerciciosEntidade> ListarExercicios();
        bool Inserir(ExerciciosEntidade exercicio);
        bool Alterar(ExerciciosEntidade exercicio);
        bool Deletar(ExerciciosEntidade exercicio);
    }
}
