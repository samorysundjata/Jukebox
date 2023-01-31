﻿using Jukebox.API.Context;
using Jukebox.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jukebox.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MusicasController : Controller
    {
        private readonly AppDbContext _context;

        public MusicasController(AppDbContext context)
        {
            _context = context;
        }

        public ActionResult<IEnumerable<Musica>> GetMusicas()
        {
            var musicas = _context.Musicas.ToList();

            if (musicas is null)
            {
                return NotFound("Não há músicas catalogadas.");
            }

            return musicas;
        }

        public  ActionResult<Musica> GetMusica(int id)
        {
            return View();
        }
    }
}
