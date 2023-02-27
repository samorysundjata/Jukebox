using Jukebox.API.Context;
using Jukebox.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            try
            {
                var artistas = _context.Artistas.ToList();
                if (artistas is null)  { return NotFound("Não foram encotrados artistas."); }
                return artistas;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                               "Ocorreu um problema ao tratar a sua solicitação.");
            }            
        }

        [HttpGet("{id:int}", Name = "TrazerArtista")]
        public ActionResult<Artista> GetArtista(int id) 
        {
            try
            {
                var artista = _context.Artistas.FirstOrDefault(a => a.ArtistaId== id);
                if (artista is null) { return NotFound("Artista não encontrado"); }
                return artista; 
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                               "Ocorreu um problema ao tratar a sua solicitação.");
            }            
        }

        [HttpPost]
        public ActionResult PostArtista(Artista artista)
        {
            try
            {
                //TODO: verificar se já existe na base antes de inserir.
                if (artista is null) { return BadRequest(); }
                _context.Artistas.Add(artista);
                _context.SaveChanges();

                return new CreatedAtRouteResult("TrazerArtista",
                    new { id = artista.ArtistaId }, artista);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                               "Ocorreu um problema ao tratar a sua solicitação.");
            }            
        }

        [HttpPut("{id:int}")]
        public ActionResult PutArtista(int id, Artista artista)
        {
            try
            {
                if (id != artista.ArtistaId) { return BadRequest(); }

                _context.Entry(artista).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok(artista);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                               "Ocorreu um problema ao tratar a sua solicitação.");
            }            
        }

        [HttpDelete]
        public ActionResult DeleteArtista(int id) 
        {
            try
            {
                var artista = _context.Artistas.FirstOrDefault(a => a.ArtistaId == id);
                if (artista is null) { return NotFound("Artista não encontrado para exclusão!"); }

                _context.Artistas.Remove(artista);
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
