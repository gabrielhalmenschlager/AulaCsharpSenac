using GerenciamentoTurmasApi.Dominio.Turmas.Entidade;

namespace GerenciamentoTurmasApi.Dominio.Exercicios.Entidade
{
    public class ExerciciosEntidade
    {
        public Guid Id { get; protected set; }
        public string Titulo { get; protected set; }
        public string Descricao { get; protected set; }
        public TurmasEntidade Turma { get; protected set; }

        public ExerciciosEntidade(string titulo, string descricao, TurmasEntidade turma)
        {
            this.SetTitulo(titulo);
            this.SetDescricao(descricao);
            this.SetTurma(turma);
        }

        public void SetTitulo(string titulo)
        {
            this.Titulo = titulo;
        }

        public void SetDescricao(string descricao)
        {
            this.Descricao = descricao;
        }

        public void SetTurma(TurmasEntidade turma)
        {
            this.Turma = turma;
        }
    }
}
