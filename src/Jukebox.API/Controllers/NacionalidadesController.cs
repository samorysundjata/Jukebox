using Jukebox.API.Context;
using Jukebox.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jukebox.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NacionalidadesController : Controller
    {
        private readonly AppDbContext _context;

        public NacionalidadesController(AppDbContext context)
        {
            _context = context;
        }

        public ActionResult<IEnumerable<Nacionalidade>> GetNacionalidades() 
        { 
            var nacionalidades = _context.Nacionalidades.ToList();

            if (nacionalidades is null)
            {
                return NotFound("Não há nacionalidades cadastradas.");
            }

            return nacionalidades;

        }
        
        public ActionResult<Nacionalidade> GetNacionalidade(string sigla)
        {
            var nacionalidade  = _context.Nacionalidades.FirstOrDefault(n => n.Sigla == sigla);

            if (nacionalidade is null)
            {
                return NotFound("Nacionalidade não encontrada.");
            }

            return nacionalidade;
        }
    }
}
