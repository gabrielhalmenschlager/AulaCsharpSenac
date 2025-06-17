using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinhaApiDDD.Dominio.Usuario.Entidade;

namespace MinhaApiDDD.Dominio.Usuario.Interfaces
{
    public interface IUsuarioServico
    {
        void Inserir(UsuarioEntidade usuario);

        List<UsuarioEntidade> ListarUsuarios();

    }
}
