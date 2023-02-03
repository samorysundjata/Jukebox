using Jukebox.API.Context;
using Jukebox.API.Models;
using Microsoft.AspNetCore.Mvc;

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
            var albuns = _context.Albuns.ToList();
            if (albuns is null) { return NotFound("Não foram encontrados álbuns."); }
            return albuns;
        }

        [HttpGet("id:int", Name ="TrazerAlbum")]
        public ActionResult<Album> GetAlbum(int id) 
        { 
            var album = _context.Albuns.FirstOrDefault(a => a.AlbumId== id);
            if(album == null) { return NotFound("Album não encontrado."); }
            return album;
        }

        [HttpPost]
        public ActionResult PostAlbum(Album album)
        {
            //TODO: verificar se já existe na base antes de inserir.
            if (album is null) { return BadRequest(); }
            _context.Albuns.Add(album);
            _context.SaveChanges();

            return new CreatedAtRouteResult("TrazerAlbum", 
                new { id = album.AlbumId}, album);
        }

        [HttpPut("{id:int}")]
        public ActionResult PutAlbum(int id, Album album)
        {
            if(album is null) { return BadRequest(); }
            return Ok(album);
        }

        [HttpDelete]
    }
}
