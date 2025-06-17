using GerenciamentoTurmasApi.Dominio.Turmas.Entidade;

namespace GerenciamentoTurmasApi.Dominio.Turmas.Interface.Servico
{
    public interface ITurmasServico
    {
        TurmasEntidade BuscarPorId(Guid id);
        List<TurmasEntidade> ListarTurmas();
        bool Inserir(TurmasEntidade turma);
        bool Alterar(TurmasEntidade turma);
        bool Deletar(TurmasEntidade turma);
    }
}
