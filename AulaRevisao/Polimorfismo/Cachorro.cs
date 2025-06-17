using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaRevisao.Polimorfismo
{
    public class Cachorro : Animal
    {
        public override void Falar()
        {
            Console.WriteLine("Au au");
        }
    }
}
