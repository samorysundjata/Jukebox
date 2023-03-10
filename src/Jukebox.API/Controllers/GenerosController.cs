using Jukebox.API.Context;
using Jukebox.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet("generos")]
        public ActionResult<IEnumerable<Genero>> GetGeneros() 
        {
            try
            {
                var generos = _context.Generos.Include(g => g.Subgeneros).ToList();
                if (generos is null) { return NotFound("Não foram encotrados gêneros registrados."); }
                return generos;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                               "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

        [HttpGet("{id:int}", Name ="TrazerGenero")]
        public ActionResult<Genero> GetGenero(int id) 
        {
            try
            {
                var genero = _context.Generos.FirstOrDefault(g => g.GeneroId == id);
                if (genero is null) { return NotFound("Gênero ou subgênero não encontrado"!); }
                return genero;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                               "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

        [HttpPost]
        public ActionResult PostGenero(Genero genero)
        {
            try
            {
                //TODO: verificar se já existe na base antes de inserir.
                if (genero is null) { return BadRequest(); }
                _context.Generos.Add(genero);
                _context.SaveChanges();

                return new CreatedAtRouteResult("TrazerGenero",
                    new { id = genero.GeneroId }, genero);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                               "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult PutGenero(int id, Genero genero)
        {
            try
            {
                if (id != genero.GeneroId) { return BadRequest(); }

                _context.Entry(genero).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok(genero);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                               "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteGenero(int id) 
        {
            try
            {
                //TODO: quando for gênero pai vai ter que bloquear a exclusão. Quando já estiver na base também.
                var genero = _context.Generos.FirstOrDefault(g => g.GeneroId == id);
                if (genero is null) { return NotFound("Gênero não encontrado para exclusão!"); }

                _context.Generos.Remove(genero);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                               "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

    }
}
