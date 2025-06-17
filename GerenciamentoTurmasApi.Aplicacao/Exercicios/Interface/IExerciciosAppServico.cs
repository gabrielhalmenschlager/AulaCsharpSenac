namespace GerenciamentoTurmasApi.Aplicacao.Exercicios.Interface
{
    public interface IExerciciosAppServico
    {
        List<ExerciciosResponse> ListarExercicios();
        ExerciciosResponse BuscarPorId(Guid Id);
        bool Inserir(ExerciciosRequest exercicio);
        bool Alterar(ExerciciosRequest exercicio);
        bool Deletar(Guid Id);
    }
}
