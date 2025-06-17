using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaApiDDD.Dominio.Usuario.Entidade
{
    public class UsuarioEntidade
    {
        public int Id { get; protected set; }
        public string Nome { get; protected set; }
        public int Idade { get; protected set; }
    
    }
}
