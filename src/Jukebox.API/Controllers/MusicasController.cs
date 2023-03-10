using Jukebox.API.Context;
using Jukebox.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet("musicas")]
        public ActionResult<IEnumerable<Musica>> GetMusicas()
        {
            try
            {
                var musicas = _context.Musicas.ToList();
                if (musicas is null)  { return NotFound("Não há músicas catalogadas."); }
                return musicas;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                               "Ocorreu um problema ao tratar a sua solicitação.");
            }

        }

        [HttpGet("{id:int}", Name ="TrazerMusica")]
        public  ActionResult<Musica> GetMusica(int id)
        {
            try
            {
                var musica = _context.Musicas.FirstOrDefault(m => m.MusicaId == id);
                if (musica is null) { return NotFound("Música não encontrada"); }
                return musica;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                               "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

        [HttpPost]
        public ActionResult PostMusica(Musica musica)
        {
            try
            {
                //TODO: verificar se já existe na base antes de inserir.
                if (musica is null) { return BadRequest(); }
                _context.Musicas.Add(musica);
                _context.SaveChanges();

                return new CreatedAtRouteResult("TrazerMusica",
                    new { id = musica.MusicaId }, musica);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                               "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult PutMusica(int id, Musica musica)
        {
            try
            {
                if (id != musica.MusicaId) { return BadRequest(); }

                _context.Entry(musica).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok(musica);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                               "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteMusica(int id)
        {
            try
            {
                var musica = _context.Musicas.FirstOrDefault(m => m.MusicaId == id);
                if (musica is null) { return NotFound("Música não encontrada para exclusão!"); }

                _context.Musicas.Remove(musica);
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
