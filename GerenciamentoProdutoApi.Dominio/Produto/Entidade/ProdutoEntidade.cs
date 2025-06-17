using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoProdutoApi.Dominio.Produto.Entidade
{
    public class ProdutoEntidade
    {
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Descricao { get; protected set; }
        public DateTime Validade { get; protected set; }
        public int Quantidade { get; protected set; }
        public bool Status { get; protected set; }
        public decimal Valor { get; protected set; }

        public ProdutoEntidade(string nome, string descricao, DateTime validade, int quantidade, bool status, decimal valor)
        {
            this.SetNome(nome);
            this.SetDescricao(descricao);
            this.SetValidade(validade); 
            this.SetQuantidade(quantidade);
            this.SetStatus(status);
            this.SetValor(valor);
        }

        public void SetNome(string nome)
        {
            this.Nome = nome;
        }

        public void SetDescricao(string descricao)
        {
            this.Descricao = descricao;
        }

        public void SetValidade(DateTime validade)
        {
            this.Validade = validade;
        }

        public void SetQuantidade(int quantidade)
        {
            this.Quantidade = quantidade;
        }

        public void SetStatus(bool status)
        {
            this.Status = status;
        }

        public void SetValor(decimal valor)
        {
            this.Valor = valor;
        }
    }
}
