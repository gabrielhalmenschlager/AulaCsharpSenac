using AutoMapper;
using GerenciamentoTurmasApi.Dominio.Exercicios.Entidade;

namespace GerenciamentoTurmasApi.Aplicacao.Exercicios.Perfil
{
    internal class ExerciciosPerfil : Profile
    {
        public ExerciciosPerfil()
        {
            CreateMap<ExerciciosRequest, ExerciciosEntidade>();
            CreateMap<ExerciciosEntidade, ExerciciosResponse>();
        }
    }
}
