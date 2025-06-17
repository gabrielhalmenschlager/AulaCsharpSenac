using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaRevisao.Encapsulamento
{
    public class Cachorro2
    {
        public string Nome { get; private set; }

        public Cachorro2(string nome)
        {
            Nome = nome;
        }

        public void SetNome2(string nome)
        {
            Nome = nome;
        }
    }
}
