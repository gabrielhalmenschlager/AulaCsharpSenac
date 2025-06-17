using GerenciamentoProdutoApi.Aplicacao.Produto.Interface;
using GerenciamentoProdutoApi.Aplicacao.Produto.Servico;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoProdutoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoAppServico produtoAppServico;

        public ProdutoController(IProdutoAppServico produtoAppServico)
        {
            this.produtoAppServico = produtoAppServico;
        }
        
        [HttpGet]
        public IActionResult ListarProdutos()
        {
            var listaProdutos = produtoAppServico.ListarProdutos();
            return Ok(listaProdutos);
        }

        [HttpGet("buscar-por-id{id}")]
        public IActionResult ListarProdutos(Guid Id)
        {
            var produto = produtoAppServico.BuscarPorId(Id);
            if (produto == null)
                return NotFound();
            
            return Ok(produto);
        }

        [HttpPost]
        public IActionResult Inserir(ProdutoRequest produtoRequest)
        {
            if (produtoRequest == null)
                return BadRequest("Erro ao ler o request!");
          
            var retorno = produtoAppServico.Inserir(produtoRequest);

            if (!retorno)
                return BadRequest("Erro ao inserir!");

            return Ok(produtoRequest);
        }


        [HttpPatch]
        public IActionResult Alterar(Guid Id, ProdutoRequest produtoRequest)
        {
            var produto = produtoAppServico.BuscarPorId(Id);

            if (produto == null)
                return NotFound();

            var retorno = produtoAppServico.Alterar(produtoRequest);

            if (!retorno)
                return BadRequest("Erro ao alterar!");

            return Ok();
        }

        [HttpDelete]
        public IActionResult Deletar(Guid Id)
        {
            var produto = produtoAppServico.BuscarPorId(Id);

            if (produto == null)
                return NotFound();

            var retorno = produtoAppServico.Deletar(Id);

            if (!retorno)
                return BadRequest("Erro ao alterar!");

            return Ok();
        }

    }
}
