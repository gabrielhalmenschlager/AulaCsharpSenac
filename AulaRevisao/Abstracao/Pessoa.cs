using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaRevisao.Abstracao
{
    public class Pessoa
    {
        public string Nome { get; set; }

        public DateTime DataDeNascimento { get; set; }
        
        public double Altura { get; set; }
        
        public double Peso { get; set; }
        
        public bool Ativo { get; set; }

        public bool IsMaiorDeIdade => DateTime.Now.Year - DataDeNascimento.Year >= 18;
    
        public void FalarNome()
        {
            Console.WriteLine($"Meu nome é {Nome}");
        }

        public string RetornarNome()
        {
            return Nome;
        }
    }
}
