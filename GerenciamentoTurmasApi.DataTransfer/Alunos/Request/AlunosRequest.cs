using GerenciamentoTurmasApi.Dominio.Turmas.Entidade;

public class AlunosRequest
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public TurmasEntidade Turma { get; set; }
}