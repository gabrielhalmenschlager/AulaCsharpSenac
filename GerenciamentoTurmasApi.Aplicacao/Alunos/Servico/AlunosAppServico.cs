using AutoMapper;
using GerenciamentoTurmasApi.Aplicacao.Alunos.Interface;
using GerenciamentoTurmasApi.Dominio.Alunos.Entidade;
using GerenciamentoTurmasApi.Dominio.Alunos.Interface.Servico;
using GerenciamentoTurmasApi.Dominio.Alunos.Servico;

namespace GerenciamentoTurmasApi.Aplicacao.Alunos.Servico
{
    public class AlunosAppServico : IAlunosAppServico
    {
        private readonly IAlunosServico AlunosServico;
        private readonly IMapper Mapper;

        public AlunosAppServico(IAlunosServico AlunosServico, IMapper mapper)
        {
            this.AlunosServico = AlunosServico;
            this.Mapper = mapper;
        }

        public bool Alterar(AlunosRequest aluno)
        {
            AlunosEntidade alunosEntidade = this.Mapper.Map<AlunosEntidade>(aluno);
            return AlunosServico.Alterar(alunosEntidade);
        }

        public AlunosResponse BuscarPorId(Guid Id)
        {
            var aluno = AlunosServico.BuscarPorId(Id);
            if (aluno == null)
                return null;

            AlunosResponse response = this.Mapper.Map<AlunosResponse>(aluno);
            return response;
        }
        public bool Deletar(Guid Id)
        {
            var aluno = AlunosServico.BuscarPorId(Id);
            return AlunosServico.Deletar(aluno);
        }

        public bool Inserir(AlunosRequest aluno)
        {
            AlunosEntidade alunosEntidade = this.Mapper.Map<AlunosEntidade>(aluno);
            return AlunosServico.Inserir(alunosEntidade);
        }

        public List<AlunosResponse> ListarAlunos()
        {
            var aluno = AlunosServico.ListarAlunos();
            if (aluno == null)
                return null;
            List<AlunosResponse> response = this.Mapper.Map<List<AlunosResponse>>(aluno);
            return response;
        }
    }
}
