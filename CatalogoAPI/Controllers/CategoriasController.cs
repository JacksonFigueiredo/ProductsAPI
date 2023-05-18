using AutoMapper;
using CatalogoAPI.Data;
using CatalogoAPI.DTOs;
using CatalogoAPI.Models;
using CatalogoAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CatalogoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        public CategoriasController(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("produtos")]
        public ActionResult<IEnumerable<CategoriaDTO>> GetCategoriasProdutos()
        {
            // return _mapper.Map<List<CategoriaDTO>>(_context.CategoriaRepository.GetCategoriasProdutos());
            var categorias = _context.CategoriaRepository.GetCategoriasProdutos().ToList();
            var categoriasDto = _mapper.Map<List<CategoriaDTO>>(categorias);
            return categoriasDto;

        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoriaDTO>> Get()
        {
            var categorias = _context.CategoriaRepository.Get().ToList();
            var categoriasDto = _mapper.Map<List<CategoriaDTO>>(categorias);
            return categoriasDto;
        }

        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<CategoriaDTO> Get(int id)
        {
            object? categoria = _mapper.Map<List<CategoriaDTO>>(_context.CategoriaRepository.GetById(o => o.CategoriaId == id));
            if (categoria == null)
            {
                return NotFound("Não Encontrado");
            }
            return (ActionResult<CategoriaDTO>)Ok(categoria);
        }

        [HttpPost]
        public ActionResult Post([FromBody] CategoriaDTO categoriaDto)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDto);

            _context.CategoriaRepository.Add(categoria);
            _context.Commit();

            var categoriaDTO = _mapper.Map<CategoriaDTO>(categoria);

            return new CreatedAtRouteResult("ObterCategoria",
                new { id = categoria.CategoriaId }, categoriaDTO);
        }


        [HttpPut("{id:int}")]
        public ActionResult Update(int? id, [FromBody] CategoriaDTO categoriaDto)
        {
            if (id == _context.CategoriaRepository.GetById(_context => _context.CategoriaId == id).CategoriaId)
            {
                return BadRequest("Probléme");
            }

            var categoria = _mapper.Map<Categoria>(categoriaDto);

            _context.CategoriaRepository.Update(categoria);
            _context.Commit();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var categoria = _context.CategoriaRepository.GetById(_context => _context.CategoriaId == id);

            if (categoria == null)
            {
                return NotFound("Não encontrado");
            }

            _context.CategoriaRepository.Delete(categoria);
            _context.Commit();
            return Ok(categoria);
        }
    }
}
