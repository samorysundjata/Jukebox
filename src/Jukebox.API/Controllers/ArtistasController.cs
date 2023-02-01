using Jukebox.API.Context;
using Jukebox.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jukebox.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArtistasController : Controller
    {
        private readonly AppDbContext _context;

        public ArtistasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Artista>> GetArtistas() 
        { 
            var artistas = _context.Artistas.ToList();
            if (artistas is null)
            {
                return NotFound("Não foram encotrados artistas.");
            }

            return artistas;
        }

        [HttpGet("{id:int}", Name = "TrazerArtista")]
        public ActionResult<Artista> GetArtista(int id) 
        { 
            var artista = _context.Artistas.FirstOrDefault(a => a.ArtistaId== id);
            if (artista is null) { return NotFound("Artista não encontrado"); }
            return artista; 
        }

        [HttpPost]

        [HttpPut]
    }
}
