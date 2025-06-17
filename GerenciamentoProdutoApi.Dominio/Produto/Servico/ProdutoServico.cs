using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciamentoProdutoApi.Dominio.Produto.Entidade;
using GerenciamentoProdutoApi.Dominio.Produto.Interface.Servico;

namespace GerenciamentoProdutoApi.Dominio.Produto.Servico
{
    public class ProdutoServico : IProdutoServico
    {
        private List<ProdutoEntidade> produtos = new List<ProdutoEntidade>();

        public bool Alterar(ProdutoEntidade produto)
        {
            try
            {
                var produtoAlterado = produtos.First(x => x.Id == produto.Id);
                produtoAlterado.SetNome(produto.Nome);
                produtoAlterado.SetDescricao(produto.Descricao);
                produtoAlterado.SetValidade(produto.Validade);
                produtoAlterado.SetQuantidade(produto.Quantidade);
                produtoAlterado.SetStatus(produto.Status);
                produtoAlterado.SetValor(produto.Valor);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public ProdutoEntidade BuscarPorId(Guid Id) 
        {
            return produtos.FirstOrDefault(x => x.Id == Id);
            
        }

        public bool Deletar(ProdutoEntidade produto)
        {
            try
            {
                if (produto == null)
                    return false;

                produtos.Remove(produto);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool Inserir(ProdutoEntidade produto)
        {
            try
            {
                produtos.Add(produto);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<ProdutoEntidade> ListarProdutos()
        {
            return produtos;
        }
    }
}
