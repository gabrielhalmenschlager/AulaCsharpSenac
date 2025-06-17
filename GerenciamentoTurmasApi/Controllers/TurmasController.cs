using GerenciamentoTurmasApi.Aplicacao.Exercicios.Interface;
using GerenciamentoTurmasApi.Aplicacao.Exercicios.Servico;
using GerenciamentoTurmasApi.Aplicacao.Turmas.Interface;
using GerenciamentoTurmasApi.Aplicacao.Turmas.Servico;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoTurmasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmasController : Controller
    {
        private readonly ITurmasAppServico turmasAppServico;

        public TurmasController(ITurmasAppServico turmasAppServico)
        {
            this.turmasAppServico = turmasAppServico;
        }

        [HttpGet]
        public IActionResult ListarTurmas()
        {
            var listaTurmas = turmasAppServico.ListarTurmas();
            return Ok(listaTurmas);
        }

        [HttpGet("buscar-por-id{id}")]
        public IActionResult ListarTurmas(Guid Id)
        {
            var turma = turmasAppServico.BuscarPorId(Id);
            if (turma == null)
                return NotFound();

            return Ok(turma);
        }

        [HttpPost]
        public IActionResult Inserir(TurmasRequest turmasRequest)
        {
            if (turmasRequest == null)
                return BadRequest("Erro ao ler o request!");

            var retorno = turmasAppServico.Inserir(turmasRequest);

            if (!retorno)
                return BadRequest("Erro ao inserir!");

            return Ok(turmasRequest);
        }


        [HttpPatch]
        public IActionResult Alterar(Guid Id, TurmasRequest turmasRequest)
        {
            var turma = turmasAppServico.BuscarPorId(Id);

            if (turma == null)
                return NotFound();

            var retorno = turmasAppServico.Alterar(turmasRequest);

            if (!retorno)
                return BadRequest("Erro ao alterar!");

            return Ok();
        }

        [HttpDelete]
        public IActionResult Deletar(Guid Id)
        {
            var turma = turmasAppServico.BuscarPorId(Id);
            if (turma == null)
                return NotFound();

            var retorno = turmasAppServico.Deletar(Id);

            if (!retorno)
                return BadRequest("Erro ao alterar!");

            return Ok();
        }
    }
}
