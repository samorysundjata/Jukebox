using Jukebox.API.Context;
using Jukebox.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jukebox.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AlbunsController : Controller
    {
        private readonly AppDbContext _context;

        public AlbunsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Album>> GetAlbuns() 
        {
            try
            {
                var albuns = _context.Albuns.ToList();
                if (albuns is null) { return NotFound("Não foram encontrados álbuns."); }
                return albuns;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                               "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

        [HttpGet("id:int", Name ="TrazerAlbum")]
        public ActionResult<Album> GetAlbum(int id) 
        {
            try
            {
                var album = _context.Albuns.FirstOrDefault(a => a.AlbumId == id);
                if (album == null) { return NotFound($"Album com id={id} não encontrado."); }
                return album;
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                               "Ocorreu um problema ao tratar a sua solicitação.");
            }            
        }

        [HttpPost]
        public ActionResult PostAlbum(Album album)
        {
            //TODO: verificar se já existe na base antes de inserir.
            try
            {
                if (album is null) { return BadRequest(); }
                _context.Albuns.Add(album);
                _context.SaveChanges();

                return new CreatedAtRouteResult("TrazerAlbum",
                    new { id = album.AlbumId }, album);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                               "Ocorreu um problema ao tratar a sua solicitação.");
            }            
        }

        [HttpPut("{id:int}")]
        public ActionResult PutAlbum(int id, Album album)
        {
            try
            {
                if (id != album.AlbumId) { return BadRequest(); }

                _context.Entry(album).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok(album);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                               "Ocorreu um problema ao tratar a sua solicitação.");
            }            
        }

        [HttpDelete]
        public ActionResult DeleteAlbum(int id) 
        {
            try
            {
                var album = _context.Albuns.FirstOrDefault(a => a.AlbumId == id);
                if (album is null) { return NotFound($"Álbum com id={id} não encontrado para exclusão!"); }

                _context.Albuns.Remove(album);
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
