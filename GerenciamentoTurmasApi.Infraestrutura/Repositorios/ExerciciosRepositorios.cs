using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciamentoProdutoApi.Infraestrutura.Dados;
using GerenciamentoTurmasApi.Dominio.Alunos.Entidade;
using GerenciamentoTurmasApi.Dominio.Exercicios.Entidade;
using GerenciamentoTurmasApi.Dominio.Exercicios.Interface.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoTurmasApi.Infraestrutura.Repositorios
{
    public class ExerciciosRepositorios : IExerciciosRepositorios
    {
        private readonly AppDbContexto _contexto;

        public ExerciciosRepositorios(AppDbContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task AdicionarAsync(ExerciciosEntidade exercicio)
        {
            _contexto.Exercicios.Add(exercicio);
            await _contexto.SaveChangesAsync();
        }

        public async Task<List<ExerciciosEntidade>> ListarAsync()
        {
            return await _contexto.Exercicios.ToListAsync();
        }

        public async Task<ExerciciosEntidade> ObterPorIdAsync(Guid id)
        {
            return await _contexto.Exercicios.FindAsync(id);
        }
    }
}
