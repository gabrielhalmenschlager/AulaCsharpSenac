using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciamentoProdutoApi.Infraestrutura.Dados;
using GerenciamentoTurmasApi.Dominio.Alunos.Entidade;
using GerenciamentoTurmasApi.Dominio.Alunos.Interface.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoTurmasApi.Infraestrutura.Repositorios
{
    public class AlunosRepositorios : IAlunosRepositorios
    {
        private readonly AppDbContexto _contexto;

        public AlunosRepositorios(AppDbContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task AdicionarAsync(AlunosEntidade aluno)
        {
            _contexto.Alunos.Add(aluno);
            await _contexto.SaveChangesAsync();
        }

        public async Task<List<AlunosEntidade>> ListarAsync()
        {
            return await _contexto.Alunos.ToListAsync();
        }

        public async Task<AlunosEntidade> ObterPorIdAsync(Guid id)
        {
            return await _contexto.Alunos.FindAsync(id);
        }
    }
}
