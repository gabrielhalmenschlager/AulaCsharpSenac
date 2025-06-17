namespace GerenciamentoTurmasApi.Aplicacao.Alunos.Interface
{
    public interface IAlunosAppServico
    {
        List<AlunosResponse> ListarAlunos();
        AlunosResponse BuscarPorId(Guid Id);
        bool Inserir(AlunosRequest aluno);
        bool Alterar(AlunosRequest aluno);
        bool Deletar(Guid Id);
    }
}
