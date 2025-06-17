using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciamentoProdutoApi.Dominio.Produto.Entidade;

namespace GerenciamentoProdutoApi.Dominio.Produto.Interface.Repositorios
{
    public interface IProdutoRepositorio
    {
        Task<List<ProdutoEntidade>> ListarAsync();

        Task<ProdutoEntidade> ObterPorIdAsync(Guid Id);

        Task AdicionarAsync(ProdutoEntidade produto);
    }
}
