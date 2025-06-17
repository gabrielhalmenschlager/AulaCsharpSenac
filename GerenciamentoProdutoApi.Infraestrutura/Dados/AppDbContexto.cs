using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciamentoProdutoApi.Dominio.Produto.Entidade;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoProdutoApi.Infraestrutura.Dados
{
    public class AppDbContexto : DbContext
    {
        public DbSet<ProdutoEntidade> Produtos { get; set; }

        public AppDbContexto(DbContextOptions<AppDbContexto> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutoEntidade>().HasKey(a => a.Id);
        }
    }
}
