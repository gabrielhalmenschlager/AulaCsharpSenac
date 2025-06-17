using GerenciamentoTurmasApi.Dominio.Exercicios.Entidade;
using GerenciamentoTurmasApi.Dominio.Exercicios.Interface.Servico;

namespace GerenciamentoTurmasApi.Dominio.Exercicios.Servico
{
    public class ExerciciosServico : IExerciciosServico
    {
        private List<ExerciciosEntidade> exercicios = new List<ExerciciosEntidade>();

        public bool Alterar(ExerciciosEntidade exercicio)
        {
            try
            {
                var exercicioAlterado = exercicios.First(x => x.Id == exercicio.Id);
                exercicioAlterado.SetTitulo(exercicio.Titulo);
                exercicioAlterado.SetDescricao(exercicio.Descricao);
                exercicioAlterado.SetTurma(exercicio.Turma);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public ExerciciosEntidade BuscarPorId(Guid Id)
        {
            return exercicios.FirstOrDefault(x => x.Id == Id);

        }

        public bool Deletar(ExerciciosEntidade exercicio)
        {
            try
            {
                if (exercicio == null)
                    return false;

                exercicios.Remove(exercicio);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Inserir(ExerciciosEntidade exercicio)
        {
            try
            {
                exercicios.Add(exercicio);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<ExerciciosEntidade> ListarExercicios()
        {
            return exercicios;
        }
    }
}
