using Microsoft.AspNetCore.Mvc;
using MinhaApiDDD.Aplicacao.Usuario.Interface;
using MinhaApiDDD.Dominio.Usuario.Entidade;

namespace PrimeiraApiDDD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAppServico usuarioAppServico;

        public UsuarioController(IUsuarioAppServico usuarioAppServico)
        {
            this.usuarioAppServico = usuarioAppServico;  
        }

        [HttpPost]
        public IActionResult Inserir(UsuarioRequest usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }

            usuarioAppServico.InserirUsuario(usuario);
            return Ok();
        }

        [HttpGet]
        public List<UsuarioResponse> Listar()
        {
            return usuarioAppServico.ListarUsuarios();
        }
    }
}
