using AutoMapper;
using GerenciamentoTurmasApi.Dominio.Turmas.Entidade;

namespace GerenciamentoTurmasApi.Aplicacao.Turmas.Perfil
{
    internal class TurmasPerfil : Profile
    {
        public TurmasPerfil()
        {
            CreateMap<TurmasRequest, TurmasEntidade>();
            CreateMap<TurmasEntidade, TurmasResponse>();
        }
    }
}
