using GerenciamentoTurmasApi.Dominio.Turmas.Entidade;

public class AlunosResponse
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public TurmasEntidade Turma { get; set; }
}
