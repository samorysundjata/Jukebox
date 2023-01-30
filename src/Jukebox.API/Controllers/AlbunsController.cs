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

        public ActionResult<IEnumerable<Album>> GetAlbuns() { return View(); }

        public ActionResult<Album> GetAlbum(int id) { return View(); }
    }
}
