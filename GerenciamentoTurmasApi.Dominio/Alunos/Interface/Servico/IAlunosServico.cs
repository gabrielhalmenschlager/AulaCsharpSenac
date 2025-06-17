using GerenciamentoTurmasApi.Dominio.Alunos.Entidade;

namespace GerenciamentoTurmasApi.Dominio.Alunos.Interface.Servico
{
    public interface IAlunosServico
    {
        AlunosEntidade BuscarPorId(Guid id);
        List<AlunosEntidade> ListarAlunos();
        bool Inserir(AlunosEntidade aluno);
        bool Alterar(AlunosEntidade aluno);
        bool Deletar(AlunosEntidade aluno);
    }
}
