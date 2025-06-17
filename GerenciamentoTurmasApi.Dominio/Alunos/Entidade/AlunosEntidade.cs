using GerenciamentoTurmasApi.Dominio.Turmas.Entidade;

namespace GerenciamentoTurmasApi.Dominio.Alunos.Entidade
{
    public class AlunosEntidade
    {
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Email { get; protected set; }
        public TurmasEntidade Turma { get; protected set; }

        public AlunosEntidade(string nome, string email, TurmasEntidade turma)
        {
            this.SetNome(nome);
            this.SetEmail(email);
            this.SetTurma(turma);
        }

        public void SetNome(string nome)
        {
            this.Nome = nome;
        }

        public void SetEmail(string email)
        {
            this.Email = email;
        }

        public void SetTurma(TurmasEntidade turma)
        {
            this.Turma = turma;
        }
    }
}
