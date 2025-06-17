using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciamentoProdutoApi.Dominio.Produto.Entidade;
using GerenciamentoProdutoApi.Dominio.Produto.Interface.Repositorios;
using GerenciamentoProdutoApi.Infraestrutura.Dados;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoProdutoApi.Infraestrutura.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly AppDbContexto _contexto;

        public ProdutoRepositorio(AppDbContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task AdicionarAsync(ProdutoEntidade produto)
        {
            _contexto.Produtos.Add(produto);
            await _contexto.SaveChangesAsync();
        }

        public async Task<List<ProdutoEntidade>> ListarAsync()
        {
            return await _contexto.Produtos.ToListAsync();
        }

        public async Task<ProdutoEntidade> ObterPorIdAsync(Guid Id)
        {
            return await _contexto.Produtos.FindAsync(Id);
        }
    }
}
