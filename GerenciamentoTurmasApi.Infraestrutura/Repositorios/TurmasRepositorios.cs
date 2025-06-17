using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciamentoProdutoApi.Infraestrutura.Dados;
using GerenciamentoTurmasApi.Dominio.Exercicios.Entidade;
using GerenciamentoTurmasApi.Dominio.Turmas.Entidade;
using GerenciamentoTurmasApi.Dominio.Turmas.Interface.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoTurmasApi.Interface.Repositorios
{
    public class TurmasRepositorios : ITurmasRepositorios
    {
        private readonly AppDbContexto _contexto;

        public TurmasRepositorios(AppDbContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task AdicionarAsync(TurmasEntidade exercicio)
        {
            _contexto.Turmas.Add(exercicio);
            await _contexto.SaveChangesAsync();
        }

        public async Task<List<TurmasEntidade>> ListarAsync()
        {
            return await _contexto.Turmas.ToListAsync();
        }

        public async Task<TurmasEntidade> ObterPorIdAsync(Guid id)
        {
            return await _contexto.Turmas.FindAsync(id);
        }
    }
}
