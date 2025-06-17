using GerenciamentoTurmasApi.Dominio.Turmas.Entidade;
using GerenciamentoTurmasApi.Dominio.Turmas.Interface.Servico;

namespace GerenciamentoTurmasApi.Dominio.Turmas.Servico
{
    public class TurmasServico : ITurmasServico
    {
        private List<TurmasEntidade> turmas = new List<TurmasEntidade>();

        public bool Alterar(TurmasEntidade turma)
        {
            try
            {
                var turmaAlterado = turmas.First(x => x.Id == turma.Id);
                turmaAlterado.SetNome(turma.Nome);
                turmaAlterado.SetAno(turma.Ano);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public TurmasEntidade BuscarPorId(Guid Id)
        {
            return turmas.FirstOrDefault(x => x.Id == Id);

        }

        public bool Deletar(TurmasEntidade turma)
        {
            try
            {
                if (turma == null)
                    return false;

                turmas.Remove(turma);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Inserir(TurmasEntidade turma)
        {
            try
            {
                turmas.Add(turma);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<TurmasEntidade> ListarTurmas()
        {
            return turmas;
        }
    }
}
