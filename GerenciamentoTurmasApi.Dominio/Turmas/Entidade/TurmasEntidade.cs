namespace GerenciamentoTurmasApi.Dominio.Turmas.Entidade
{
    public class TurmasEntidade
    {
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }
        public int Ano { get; protected set; }

        public TurmasEntidade(string nome, int ano)
        {
            this.SetNome(nome);
            this.SetAno(ano);
        }

        public void SetNome(string nome)
        {
            this.Nome = nome;
        }

        public void SetAno(int ano)
        {
            this.Ano = ano;
        }
    }
}
