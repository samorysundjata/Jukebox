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

            if (generos is null)
            {
                return NotFound("Não foram encotrados gêneros registrados.");
            }

            return generos;
        }

        public ActionResult<Genero> GetGenero(int id) { return View(); }

        public ActionResult<IEnumerable<Subgenero>> GetSubgeneros() 
        { 
            var subgeneros  = _context.Subgeneros.ToList();

            if (subgeneros is null)
            {
                return NotFound("Não há subgêneros cadastrados.");
            }

            return subgeneros;
        }

        public ActionResult<Subgenero> GetSubgenero(int id) { return View(); }

    }
}
