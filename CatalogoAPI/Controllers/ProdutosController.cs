using CatalogoAPI.Data;
using CatalogoAPI.Models;
using CatalogoAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Mozilla;

namespace CatalogoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IUnitOfWork _context;
        public ProdutosController(IUnitOfWork context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _context.ProdutoRepository.Get().ToList();
            if (produtos == null)
            {
                return NotFound();
            }
            return Ok(produtos);
        }

        [HttpGet("{id:int}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id) //Mais Indicado
        {
            var produto = _context.ProdutoRepository.GetById(x => x.ProdutoId == id);
            if (produto == null)
            {
                return NotFound("Não Encontrado");
            }
            return Ok(produto);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Produto produto)
        {
            if (produto == null)
                BadRequest();

            _context.ProdutoRepository.Add(produto);
            _context.Commit();

            return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto);
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest();
            }

            _context.ProdutoRepository.Update(produto);
            _context.Commit();

            return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var produto = _context.ProdutoRepository.GetById(_context => _context.ProdutoId == id);

            if (produto == null)
            {
                return NotFound("Não encontrado");
            }

            _context.ProdutoRepository.Delete(produto);
            _context.Commit();
            return Ok(produto);
        }
    }
}
