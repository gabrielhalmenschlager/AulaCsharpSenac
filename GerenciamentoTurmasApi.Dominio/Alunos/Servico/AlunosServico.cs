using GerenciamentoTurmasApi.Dominio.Alunos.Entidade;
using GerenciamentoTurmasApi.Dominio.Alunos.Interface.Servico;

namespace GerenciamentoTurmasApi.Dominio.Alunos.Servico
{
    public class AlunosServico : IAlunosServico
    {
        private List<AlunosEntidade> alunos = new List<AlunosEntidade>();

        public bool Alterar(AlunosEntidade aluno)
        {
            try
            {
                var alunoAlterado = alunos.First(x => x.Id == aluno.Id);
                alunoAlterado.SetNome(aluno.Nome);
                alunoAlterado.SetEmail(aluno.Email);
                alunoAlterado.SetTurma(aluno.Turma);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public AlunosEntidade BuscarPorId(Guid Id)
        {
            return alunos.FirstOrDefault(x => x.Id == Id);

        }

        public bool Deletar(AlunosEntidade aluno)
        {
            try
            {
                if (aluno == null)
                    return false;

                alunos.Remove(aluno);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Inserir(AlunosEntidade aluno)
        {
            try
            {
                alunos.Add(aluno);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<AlunosEntidade> ListarAlunos()
        {
            return alunos;
        }
    }
}
