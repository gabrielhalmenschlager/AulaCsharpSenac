using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaRevisao.Polimorfismo
{
    public abstract class Animal
    {
        public string Nome { get; set; }

        public DateTime DataDeNascimento { get; set; }

        public double Peso { get; set; }

        public abstract void Falar();   

        public void Caminhar()
        {
            Console.WriteLine($"Animal caminhando pq ambos tem 4 patas.");
        }
    }
}
