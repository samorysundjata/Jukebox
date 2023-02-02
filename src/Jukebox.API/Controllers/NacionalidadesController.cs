using Jukebox.API.Context;
using Jukebox.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public ActionResult<IEnumerable<Nacionalidade>> GetNacionalidades() 
        { 
            var nacionalidades = _context.Nacionalidades.ToList();
            if (nacionalidades is null)  { return NotFound("Não há nacionalidades cadastradas."); }
            return nacionalidades;
        }

        [HttpGet("{sigla:string}", Name = "TrazerNacionalidade")]
        public ActionResult<Nacionalidade> GetNacionalidade(string sigla)
        {
            var nacionalidade  = _context.Nacionalidades.FirstOrDefault(n => n.Sigla == sigla);
            if (nacionalidade is null)  { return NotFound("Nacionalidade não encontrada."); }
            return nacionalidade;
        }

        [HttpPost]
        public ActionResult PostNacionalidade(Nacionalidade nacionalidade)
        {
            //TODO: verificar se a sigla já existe antes de inserir
            if(nacionalidade is null) { return BadRequest(); }
            _context.Nacionalidades.Add(nacionalidade);
            _context.SaveChanges();

            return new CreatedAtRouteResult("TrazerNacionalidade", 
                new { sigla = nacionalidade.Sigla }, nacionalidade);
        }

        [HttpPut("sigla:string")]
        public ActionResult PutNacionalidade(string sigla, Nacionalidade nacionalidade)
        {
            if (sigla != nacionalidade.Sigla) { return BadRequest(); }        
            
            _context.Entry(nacionalidade).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(nacionalidade);
        }

        [HttpDelete]
        public ActionResult DeleteNacionalidade(string sigla)
        {
            var nacionalidade = _context.Nacionalidades.FirstOrDefault(n => n.Sigla == sigla);

            if (nacionalidade is null) { return NotFound("Nacionalidade não encontrada para exclusão."); }

            _context.Nacionalidades.Remove(nacionalidade);
            _context.SaveChanges();

            return Ok(nacionalidade);
        }

    }
}
