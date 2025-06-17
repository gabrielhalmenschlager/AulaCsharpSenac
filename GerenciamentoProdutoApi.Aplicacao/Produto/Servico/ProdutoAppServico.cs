using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GerenciamentoProdutoApi.Aplicacao.Produto.Interface;
using GerenciamentoProdutoApi.Dominio.Produto.Entidade;
using GerenciamentoProdutoApi.Dominio.Produto.Interface.Servico;

namespace GerenciamentoProdutoApi.Aplicacao.Produto.Servico
{
    public class ProdutoAppServico : IProdutoAppServico
    {
        private readonly IProdutoServico ProdutoServico;
        private readonly IMapper Mapper;

        public ProdutoAppServico(IProdutoServico ProdutoServico, IMapper mapper)
        {
            this.ProdutoServico = ProdutoServico;
            this.Mapper = mapper;
        }

        public bool Alterar(ProdutoRequest produto)
        {
            ProdutoEntidade produtoEntidade = this.Mapper.Map<ProdutoEntidade>(produto);
            return ProdutoServico.Alterar(produtoEntidade);
        }

        public ProdutoResponse BuscarPorId(Guid Id)
        {
            var produto = ProdutoServico.BuscarPorId(Id);
            if (produto == null)
                return null;
            
            ProdutoResponse response = this.Mapper.Map<ProdutoResponse>(produto);
            return response;
        }
        public bool Deletar(Guid Id)
        {
            var produto = ProdutoServico.BuscarPorId(Id);
            return ProdutoServico.Deletar(produto);

        }

        public bool Inserir(ProdutoRequest produto)
        {
            ProdutoEntidade produtoEntidade = this.Mapper.Map<ProdutoEntidade>(produto);
            return ProdutoServico.Inserir(produtoEntidade);
        }

        public List<ProdutoResponse> ListarProdutos()
        {
            var produto = ProdutoServico.ListarProdutos();
            if (produto == null)
                return null;
            List<ProdutoResponse> response = this.Mapper.Map<List<ProdutoResponse>>(produto);
            return response;
        }
    }
}
