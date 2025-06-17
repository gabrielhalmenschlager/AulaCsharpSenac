using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CadastroCarroService;

namespace ApiCadastroCarro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        // private static List<Carro> carros = new List<Carro>();

        /*

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(carros);
        }

        */

        [HttpPost]
        public IActionResult Post(Carro carro)
        {
            CarroService carroService = new CarroService();

            string retorno = carroService.ValidarCarro(carro);

            if (retorno != "Sucesso")
            {
                return BadRequest(retorno);
            }
            
            return Ok(retorno);
        }

        /*

        [HttpPost]
        public IActionResult Post([FromBody] Carro carro)
        {
            if (string.IsNullOrWhiteSpace(carro.Nome))
                return BadRequest("Nome deve ser informado!");

            carro.Id = Guid.NewGuid();

            carros.Add(carro);
            return Created("", carro);
        }

        */

        /*

        [HttpPatch]
        public IActionResult Patch(Guid id, [FromBody] Carro carro)
        {
            if (carro == null)
                return BadRequest();

            var carroExistente = GetById(id);
            if (carroExistente == null)
                return NotFound();

            carroExistente.Nome = carro.Nome;
            carroExistente.Modelo = carro.Modelo;
            carroExistente.Marca = carro.Marca;
            carroExistente.Cor = carro.Cor;
            carroExistente.Ano = carro.Ano;

            return Ok(carroExistente);
        }


        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var obj = GetById(id);
            if (obj == null)
                return NotFound();

            carros.Remove(obj);
            return Ok();
        }

        [HttpGet("GetById")]
        public Carro GetById(Guid id)
        {
            return carros.FirstOrDefault(x => x.Id == id);
        }

        */

    }
}
