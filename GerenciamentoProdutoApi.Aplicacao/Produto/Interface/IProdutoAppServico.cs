using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoProdutoApi.Aplicacao.Produto.Interface
{
    public interface IProdutoAppServico
    {
        List<ProdutoResponse> ListarProdutos();
        ProdutoResponse BuscarPorId(Guid Id);
        bool Inserir(ProdutoRequest produto);
        bool Alterar(ProdutoRequest produto);
        bool Deletar(Guid Id);

    }
}
