using GerenciamentoTurmasApi.Aplicacao.Alunos.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoTurmasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : Controller
    {
        private readonly IAlunosAppServico alunosAppServico;

        public AlunosController(IAlunosAppServico alunosAppServico)
        {
            this.alunosAppServico = alunosAppServico;
        }

        [HttpGet]
        public IActionResult ListarAlunos()
        {
            var listaAlunos = alunosAppServico.ListarAlunos();
            return Ok(listaAlunos);
        }

        [HttpGet("buscar-por-id{id}")]
        public IActionResult ListarAlunos(Guid Id)
        {
            var aluno = alunosAppServico.BuscarPorId(Id);
            if (aluno == null)
                return NotFound();

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Inserir(AlunosRequest alunosRequest)
        {
            if (alunosRequest == null)
                return BadRequest("Erro ao ler o request!");

            var retorno = alunosAppServico.Inserir(alunosRequest);

            if (!retorno)
                return BadRequest("Erro ao inserir!");

            return Ok(alunosRequest);
        }


        [HttpPatch]
        public IActionResult Alterar(Guid Id, AlunosRequest alunosRequest)
        {
            var aluno = alunosAppServico.BuscarPorId(Id);

            if (aluno == null)
                return NotFound();

            var retorno = alunosAppServico.Alterar(alunosRequest);

            if (!retorno)
                return BadRequest("Erro ao alterar!");

            return Ok();
        }

        [HttpDelete]
        public IActionResult Deletar(Guid Id)
        {
            var aluno = alunosAppServico.BuscarPorId(Id);

            if (aluno == null)
                return NotFound();

            var retorno = alunosAppServico.Deletar(Id);

            if (!retorno)
                return BadRequest("Erro ao alterar!");

            return Ok();
        }
    }
}
