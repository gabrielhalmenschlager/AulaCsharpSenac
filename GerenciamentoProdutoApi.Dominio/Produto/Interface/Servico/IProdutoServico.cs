using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciamentoProdutoApi.Dominio.Produto.Entidade;

namespace GerenciamentoProdutoApi.Dominio.Produto.Interface.Servico
{
    public interface IProdutoServico
    {
        ProdutoEntidade BuscarPorId(Guid id);
        List<ProdutoEntidade> ListarProdutos();
        bool Inserir(ProdutoEntidade produto);
        bool Alterar(ProdutoEntidade produto);
        bool Deletar(ProdutoEntidade produto);
    }
}

