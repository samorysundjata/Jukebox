﻿using Jukebox.API.Context;
using Jukebox.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jukebox.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GenerosController : Controller
    {
        private readonly AppDbContext _context;

        public GenerosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Genero>> GetGeneros() 
        { 
            var generos = _context.Generos.ToList();
            if (generos is null) { return NotFound("Não foram encotrados gêneros registrados."); }
            return generos;
        }

        [HttpGet("{id:int}", Name ="TrazerGenero")]
        public ActionResult<Genero> GetGenero(int id) 
        {
            var genero = _context.Generos.FirstOrDefault(g => g.GeneroId == id);
            if(genero is null) { return NotFound("Gênero ou subgênero não encontrado"!); }
            return genero;
        }

        [HttpPost]
        public ActionResult PostGenero(Genero genero)
        {
            return View(genero);
        }

        [HttpPut]      

    }
}
