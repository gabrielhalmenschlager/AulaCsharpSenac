using AutoMapper;
using GerenciamentoTurmasApi.Dominio.Alunos.Entidade;

namespace GerenciamentoTurmasApi.Aplicacao.Alunos.Perfil
{
    internal class AlunosPerfil : Profile
    {
        public AlunosPerfil()
        {
            CreateMap<AlunosRequest, AlunosEntidade>();
            CreateMap<AlunosEntidade, AlunosResponse>();
        }
    }
}
