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

        public ActionResult<IEnumerable<Artista>> GetArtistas() 
        { 
            var artistas = _context.Artistas.ToList();

            return View(); 
        }

        public ActionResult<Artista> GetArtista(int id) { return View(); }
    }
}
