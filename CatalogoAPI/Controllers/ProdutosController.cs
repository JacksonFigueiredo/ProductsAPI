using AutoMapper;
using CatalogoAPI.Data;
using CatalogoAPI.DTOs;
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
        private readonly IMapper _mapper;
        public ProdutosController(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProdutoDTO>> Get()
        {
            var produtos = _context.ProdutoRepository.Get().ToList();
            if (produtos == null)
            {
                return NotFound();
            }

            var produtosDto = _mapper.Map<List<ProdutoDTO>>(produtos);

            return Ok(produtosDto);
        }

        [HttpGet("{id:int}", Name = "ObterProduto")]
        public ActionResult<ProdutoDTO> Get(int id)
        {
            var produto = _context.ProdutoRepository.GetById(x => x.ProdutoId == id);
            if (produto == null)
            {
                return NotFound("Não Encontrado");
            }

            var produtoDTO = _mapper.Map<ProdutoDTO>(produto);

            return Ok(produtoDTO);
        }

        [HttpPost]
        public ActionResult Post([FromBody] ProdutoDTO produtoDto)
        {
            if (produtoDto == null)
            {
                BadRequest();
            }

            var produto = _mapper.Map<Produto>(produtoDto);


            _context.ProdutoRepository.Add(produto);
            _context.Commit();

            var produtoDTO = _mapper.Map<ProdutoDTO>(produto);

            return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produtoDTO);
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] ProdutoDTO produtoDto)
        {
            if (id != produtoDto.ProdutoId)
            {
                return BadRequest();
            }

            var produto = _mapper.Map<Produto>(produtoDto);

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
