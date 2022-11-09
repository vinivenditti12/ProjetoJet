using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_CRUD.Interfaces.Services;
using Projeto_CRUD.Model;

namespace Projeto_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private IProdutoService _service;

        public ProdutosController(IProdutoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetProdutos()
        {
            var produtos = await _service.GetProdutos();

            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var produto = await _service.GetById(id);

                return Ok(produto);
            }
            catch (Exception e)
            {
               return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProduto(Produto produtoToAdd)
        {
            try
            {
                var produto = await _service.AddProduto(produtoToAdd);

                return Ok(produto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduto(Produto produtoToUpdate)
        {
            try
            {
                var produto = await _service.UpdateProduto(produtoToUpdate);

                return Ok(produto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            try
            {
                var produto = await _service.DeleteProduto(id);

                return Ok(produto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }
}
