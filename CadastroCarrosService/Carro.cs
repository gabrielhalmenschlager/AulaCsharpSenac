using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroCarroService
{
    public class Carro
    {
        public Guid Id { get; set; } = new Guid();

        public string Nome { get; set; }

        public int Ano { get; set; }

        public string Modelo { get; set; }

        public string Marca { get; set; }

        public string Cor { get; set; }

    }
}
