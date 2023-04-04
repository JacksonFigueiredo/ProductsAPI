using CatalogoAPI.Data;
using CatalogoAPI.Models;
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
        private readonly AppDbContext _context;
        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var produtos = await _context.Produtos.AsNoTracking().ToListAsync();
            if (produtos == null)
            {
                return NotFound();
            }
            return Ok(produtos);
        }

        [HttpGet("{id:int}", Name = "ObterProduto")]
        public async Task<ActionResult<Produto>> Get(int id) //Mais Indicado
        {
            var produto = await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(x => x.ProdutoId == id);
            if (produto == null)
            {
                return NotFound("Não Encontrado");
            }
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Produto produto)
        {
            if (produto == null)
                BadRequest();

            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto);
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(_context => _context.ProdutoId == id);

            if (produto == null)
            {
                return NotFound("Não encontrado");
            }

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return Ok(produto);
        }
    }
}
