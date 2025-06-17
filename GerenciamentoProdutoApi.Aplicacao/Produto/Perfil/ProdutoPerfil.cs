using AutoMapper;
using GerenciamentoProdutoApi.Dominio.Produto.Entidade;

namespace GerenciamentoProdutoApi.Aplicacao.Produto.Perfil
{
    internal class ProdutoPerfil : Profile
    {
        public ProdutoPerfil()
        {
            CreateMap<ProdutoRequest, ProdutoResponse>();
            CreateMap<ProdutoResponse, ProdutoEntidade>();
        }
    }
}