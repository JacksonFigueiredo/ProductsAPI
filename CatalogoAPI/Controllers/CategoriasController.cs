﻿using AutoMapper;
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
            return _mapper.Map<List<CategoriaDTO>>(_context.CategoriaRepository.GetCategoriasProdutos());
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            var categorias = _context.CategoriaRepository.Get().ToList();
            if (categorias == null)
            {
                return NotFound();
            }
            return categorias;
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
        public ActionResult Post([FromBody] Categoria categoria)
        {
            if (categoria == null)
                BadRequest();

            _context.CategoriaRepository.Add(categoria);
            _context.Commit();

            return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriaId }, categoria);
        }


        [HttpPut("{id:int}")]
        public ActionResult Update(int id, [FromBody] Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return BadRequest();
            }

           _context.CategoriaRepository.Update(categoria);
            _context.Commit();

            return Ok(categoria);
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
