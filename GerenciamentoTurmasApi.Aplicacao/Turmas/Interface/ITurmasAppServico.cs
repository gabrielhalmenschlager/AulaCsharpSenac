namespace GerenciamentoTurmasApi.Aplicacao.Turmas.Interface
{
    public interface ITurmasAppServico
    {
        List<TurmasResponse> ListarTurmas();
        TurmasResponse BuscarPorId(Guid Id);
        bool Inserir(TurmasRequest turma);
        bool Alterar(TurmasRequest turma);
        bool Deletar(Guid Id);
    }
}
