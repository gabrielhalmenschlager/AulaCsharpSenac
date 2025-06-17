using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GerenciamentoProdutoApi.Infraestrutura.Dados
{
    public class AppDbContextoFactory : IDesignTimeDbContextFactory<AppDbContexto>
    {
        public AppDbContexto CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContexto>();

            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=GerenciamentoProdutoDb; Trusted_Connection=True;");

            return new AppDbContexto(optionsBuilder.Options);
        }
    }
}
