using GerenciamentoTurmasApi.Aplicacao.Alunos.Interface;
using GerenciamentoTurmasApi.Aplicacao.Alunos.Servico;
using GerenciamentoTurmasApi.Aplicacao.Exercicios.Interface;
using GerenciamentoTurmasApi.Aplicacao.Exercicios.Servico;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoTurmasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciciosController : Controller
    {
        private readonly IExerciciosAppServico exerciciosAppServico;

        public ExerciciosController(IExerciciosAppServico exerciciosAppServico)
        {
            this.exerciciosAppServico = exerciciosAppServico;
        }

        [HttpGet]
        public IActionResult ListarExercicios()
        {
            var listaExercicios = exerciciosAppServico.ListarExercicios();
            return Ok(listaExercicios);
        }

        [HttpGet("buscar-por-id{id}")]
        public IActionResult ListarExercicios(Guid Id)
        {
            var exercicio = exerciciosAppServico.BuscarPorId(Id);
            if (exercicio == null)
                return NotFound();

            return Ok(exercicio);
        }

        [HttpPost]
        public IActionResult Inserir(ExerciciosRequest exerciciosRequest)
        {
            if (exerciciosRequest == null)
                return BadRequest("Erro ao ler o request!");

            var retorno = exerciciosAppServico.Inserir(exerciciosRequest);

            if (!retorno)
                return BadRequest("Erro ao inserir!");

            return Ok(exerciciosRequest);
        }


        [HttpPatch]
        public IActionResult Alterar(Guid Id, ExerciciosRequest exerciciosRequest)
        {
            var exercicio = exerciciosAppServico.BuscarPorId(Id);

            if (exercicio == null)
                return NotFound();

            var retorno = exerciciosAppServico.Alterar(exerciciosRequest);

            if (!retorno)
                return BadRequest("Erro ao alterar!");

            return Ok();
        }

        [HttpDelete]
        public IActionResult Deletar(Guid Id)
        {
            var exercicio = exerciciosAppServico.BuscarPorId(Id);

            if (exercicio == null)
                return NotFound();

            var retorno = exerciciosAppServico.Deletar(Id);

            if (!retorno)
                return BadRequest("Erro ao alterar!");

            return Ok();
        }
    }
}
