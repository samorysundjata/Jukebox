using Jukebox.API.Context;
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

        [HttpGet]
        public ActionResult<IEnumerable<Musica>> GetMusicas()
        {
            var musicas = _context.Musicas.ToList();
            if (musicas is null)  { return NotFound("Não há músicas catalogadas."); }
            return musicas;
        }

        [HttpGet("{id:int}", Name ="TrazerMusica")]
        public  ActionResult<Musica> GetMusica(int id)
        {
            var musica = _context.Musicas.FirstOrDefault(m => m.MusicaId == id);
            if (musica is null) { return NotFound("Música não encontrada"); }
            return musica;
        }

        [HttpPost]
        public ActionResult PostMusica(Musica musica)
        {
            return View(musica);
        }

        [HttpPut]
    }
}
