using GerenciamentoProdutoApi.Infraestrutura.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GerenciamentoTurmasApi.Infraestrutura.Factories
{
    public class AppDbContextoFactory : IDesignTimeDbContextFactory<AppDbContexto>
    {
        public AppDbContexto CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContexto>();

            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=GerenciamentoTurmasDb; Trusted_Connection=True;");

            return new AppDbContexto(optionsBuilder.Options);
        }
    }
}
