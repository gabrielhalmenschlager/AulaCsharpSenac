using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinhaApiDDD.Dominio.Usuario.Entidade;
using MinhaApiDDD.Dominio.Usuario.Interfaces;

namespace MinhaApiDDD.Dominio.Usuario
{
    public class UsuarioServico : IUsuarioServico
    {
        private List<UsuarioEntidade> usuarios = new List<UsuarioEntidade>();

        public void Inserir(UsuarioEntidade usuario)
        {   
            usuarios.Add(usuario);
        }

        public List<UsuarioEntidade> ListarUsuarios()
        {
            return usuarios;
        }
    }
}
