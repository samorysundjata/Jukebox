using Jukebox.API.Context;
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

        public ActionResult<IEnumerable<Genero>> GetGeneros() 
        { 
            var generos = _context.Generos.ToList();
            
            return View(); 
        }

        public ActionResult<Genero> GetGenero(int id) { return View(); }

        public ActionResult<IEnumerable<Subgenero>> GetSubgeneros() 
        { 
            var subgeneros  = _context.Subgeneros.ToList();

            return View(); 
        }

        public ActionResult<Subgenero> GetSubgenero(int id) { return View(); }

    }
}
