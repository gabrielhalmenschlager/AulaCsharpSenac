using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PrimeiraApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(pessoas);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Pessoa pessoa)
        {
            if (string.IsNullOrWhiteSpace(pessoa.Nome))
                return BadRequest("Nome deve ser informado!");

            pessoa.Id = Guid.NewGuid();

            pessoas.Add(pessoa);
            return Created("", pessoa);
        }

        [HttpPatch]
        public IActionResult Patch(Guid id, [FromBody] Pessoa pessoa)
        {
            if (pessoa == null)
                return BadRequest();

            if (GetById(id) == null)
                return NotFound();

            pessoas.First(x => x.Id == id).Nome = pessoa.Nome;
            return Ok(pessoa);
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var obj = GetById(id);
            if (obj == null)
                return NotFound();

            pessoas.Remove(obj);
            return Ok();
        }

        [HttpGet("GetById")]
        public Pessoa GetById(Guid id)
        {
            return pessoas.FirstOrDefault(x => x.Id == id);
        }
    }
}
