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
            var artistas = _context.Artistas.ToList();
            if (artistas is null)  { return NotFound("Não foram encotrados artistas."); }
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
        public ActionResult PostArtista(Artista artista)
        {
            //TODO: verificar se já existe na base antes de inserir.
            if(artista is null) { return BadRequest(); }
            _context.Artistas.Add(artista);
            _context.SaveChanges();
            
            return new CreatedAtRouteResult("TrazerArtista", 
                new { id = artista.ArtistaId }, artista);
        }

        [HttpPut("{id:int}")]
        public ActionResult PutArtista(int id, Artista artista)
        {
            if(id  != artista.ArtistaId) { return BadRequest(); }

            _context.Entry(artista).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(artista);
        }

        [HttpDelete]
        public ActionResult DeleteArtista(int id) 
        {
            var artista = _context.Artistas.FirstOrDefault(a => a.ArtistaId == id);
            if (artista is null) { return NotFound("Artista não encontrado para exclusão!"); }
            return Ok();
        }
    }
}
