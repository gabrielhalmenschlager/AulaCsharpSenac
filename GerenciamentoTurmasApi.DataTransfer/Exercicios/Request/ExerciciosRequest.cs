using GerenciamentoTurmasApi.Dominio.Turmas.Entidade;

public class ExerciciosRequest
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public TurmasEntidade Turma { get; set; }
}
