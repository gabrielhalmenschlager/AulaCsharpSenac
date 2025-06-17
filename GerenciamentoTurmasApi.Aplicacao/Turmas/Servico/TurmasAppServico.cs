using AutoMapper;
using GerenciamentoTurmasApi.Aplicacao.Turmas.Interface;
using GerenciamentoTurmasApi.Dominio.Turmas.Entidade;
using GerenciamentoTurmasApi.Dominio.Turmas.Interface.Servico;
using GerenciamentoTurmasApi.Dominio.Turmas.Servico;

namespace GerenciamentoTurmasApi.Aplicacao.Turmas.Servico
{
    public class TurmasAppServico : ITurmasAppServico
    {
        private readonly ITurmasServico TurmasServico;
        private readonly IMapper Mapper;

        public TurmasAppServico(ITurmasServico TurmasServico, IMapper mapper)
        {
            this.TurmasServico = TurmasServico;
            this.Mapper = mapper;
        }

        public bool Alterar(TurmasRequest turma)
        {
            TurmasEntidade turmasEntidade = this.Mapper.Map<TurmasEntidade>(turma);
            return TurmasServico.Alterar(turmasEntidade);
        }

        public TurmasResponse BuscarPorId(Guid Id)
        {
            var turma = TurmasServico.BuscarPorId(Id);
            if (turma == null)
                return null;

            TurmasResponse response = this.Mapper.Map<TurmasResponse>(turma);
            return response;
        }
        public bool Deletar(Guid Id)
        {
            var turma = TurmasServico.BuscarPorId(Id);
            return TurmasServico.Deletar(turma);
        }

        public bool Inserir(TurmasRequest turma)
        {
            TurmasEntidade turmasEntidade = this.Mapper.Map<TurmasEntidade>(turma);
            return TurmasServico.Inserir(turmasEntidade);
        }

        public List<TurmasResponse> ListarTurmas()
        {
            var turma = TurmasServico.ListarTurmas();
            if (turma == null)
                return null;
            List<TurmasResponse> response = this.Mapper.Map<List<TurmasResponse>>(turma);
            return response;
        }
    }
}
