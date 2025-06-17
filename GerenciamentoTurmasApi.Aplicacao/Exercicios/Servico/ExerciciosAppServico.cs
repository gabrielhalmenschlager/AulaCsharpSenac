using AutoMapper;
using GerenciamentoTurmasApi.Aplicacao.Exercicios.Interface;
using GerenciamentoTurmasApi.Dominio.Exercicios.Entidade;
using GerenciamentoTurmasApi.Dominio.Exercicios.Interface.Servico;
using GerenciamentoTurmasApi.Dominio.Exercicios.Servico;

namespace GerenciamentoTurmasApi.Aplicacao.Exercicios.Servico
{
    public class ExerciciosAppServico : IExerciciosAppServico
    {
        private readonly IExerciciosServico ExerciciosServico;
        private readonly IMapper Mapper;

        public ExerciciosAppServico(IExerciciosServico ExerciciosServico, IMapper mapper)
        {
            this.ExerciciosServico = ExerciciosServico;
            this.Mapper = mapper;
        }

        public bool Alterar(ExerciciosRequest exercicio)
        {
            ExerciciosEntidade exerciciosEntidade = this.Mapper.Map<ExerciciosEntidade>(exercicio);
            return ExerciciosServico.Alterar(exerciciosEntidade);
        }

        public ExerciciosResponse BuscarPorId(Guid Id)
        {
            var exercicio = ExerciciosServico.BuscarPorId(Id);
            if (exercicio == null)
                return null;

            ExerciciosResponse response = this.Mapper.Map<ExerciciosResponse>(exercicio);
            return response;
        }
        public bool Deletar(Guid Id)
        {
            var exercicio = ExerciciosServico.BuscarPorId(Id);
            return ExerciciosServico.Deletar(exercicio);
        }

        public bool Inserir(ExerciciosRequest exercicio)
        {
            ExerciciosEntidade exerciciosEntidade = this.Mapper.Map<ExerciciosEntidade>(exercicio);
            return ExerciciosServico.Inserir(exerciciosEntidade);
        }

        public List<ExerciciosResponse> ListarExercicios()
        {
            var exercicio = ExerciciosServico.ListarExercicios();
            if (exercicio == null)
                return null;
            List<ExerciciosResponse> response = this.Mapper.Map<List<ExerciciosResponse>>(exercicio);
            return response;
        }
    }
}
