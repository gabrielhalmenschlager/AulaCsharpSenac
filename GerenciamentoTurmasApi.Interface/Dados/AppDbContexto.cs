using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using GerenciamentoTurmasApi.Dominio.Alunos.Entidade;
using GerenciamentoTurmasApi.Dominio.Exercicios.Entidade;
using GerenciamentoTurmasApi.Dominio.Turmas.Entidade;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoProdutoApi.Infraestrutura.Dados
{
    public class AppDbContexto : DbContext
    {
        public DbSet<AlunosEntidade> Alunos{ get; set; }
        public DbSet<ExerciciosEntidade> Exercicios{ get; set; }
        public DbSet<TurmasEntidade> Turmas { get; set; }

        public AppDbContexto(DbContextOptions<AppDbContexto> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlunosEntidade>().HasKey(a => a.Id);
            modelBuilder.Entity<ExerciciosEntidade>().HasKey(a => a.Id);
            modelBuilder.Entity<TurmasEntidade>().HasKey(a => a.Id);
        }
    }
}
