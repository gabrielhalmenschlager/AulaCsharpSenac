using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MinhaApiDDD.Aplicacao.Usuario.Interface;
using MinhaApiDDD.Dominio.Usuario.Entidade;
using MinhaApiDDD.Dominio.Usuario.Interfaces;

namespace MinhaApiDDD.Aplicacao.Usuario
{
    public class UsuarioAppServico : IUsuarioAppServico
    {
        private readonly IUsuarioServico UsuarioServico;
        private readonly IMapper Mapper;    
        public UsuarioAppServico(IUsuarioServico UsuarioServico, IMapper mapper)
        {
            this.UsuarioServico = UsuarioServico;
            this.Mapper = mapper;
        }

        public void InserirUsuario(UsuarioRequest usuario)
        {
            UsuarioEntidade entidade = Mapper.Map<UsuarioEntidade>(usuario);
            UsuarioServico.Inserir(entidade);
        }   

        public List<UsuarioResponse> ListarUsuarios()
        {
            var entidade = UsuarioServico.ListarUsuarios();
            List<UsuarioResponse> usuario = Mapper.Map<List<UsuarioResponse>>(entidade);
            return usuario;
        }
    }
}
