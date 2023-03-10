using Jukebox.API.Context;
using Jukebox.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

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

        [HttpGet("nacionalidades")]
        public ActionResult<IEnumerable<Nacionalidade>> GetNacionalidades() 
        {
            try
            {
                var nacionalidades = _context.Nacionalidades.ToList();
                if (nacionalidades is null)  { return NotFound("Não há nacionalidades cadastradas."); }
                return nacionalidades;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                               "Ocorreu um problema ao tratar a sua solicitação.");
            }

        }

        [HttpGet("{sigla}", Name = "TrazerNacionalidade")]       
        public ActionResult<Nacionalidade> GetNacionalidade(string sigla)
        {
            try
            {
                var nacionalidade = _context.Nacionalidades.FirstOrDefault(n => n.Sigla == sigla);
                if (nacionalidade is null) { return NotFound("Nacionalidade não encontrada."); }
                return nacionalidade;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                               "Ocorreu um problema ao tratar a sua solicitação.");
            }

        }

        [HttpPost]
        public ActionResult PostNacionalidade(Nacionalidade nacionalidade)
        {
            try
            {
                var existeNacionalidade = _context.Nacionalidades.FirstOrDefault(n => n.Nome == nacionalidade.Nome);
                if (existeNacionalidade is not null) { return BadRequest("Já existe nacionalidade com este nome "); }

                if (nacionalidade is null) { return BadRequest(); }
                _context.Nacionalidades.Add(nacionalidade);
                _context.SaveChanges();

                return new CreatedAtRouteResult("TrazerNacionalidade", 
                    new { sigla = nacionalidade.Sigla }, nacionalidade);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                               "Ocorreu um problema ao tratar a sua solicitação.");
            }

        }

        [HttpPut("{sigla}")]
        public ActionResult PutNacionalidade(string sigla, Nacionalidade nacionalidade)
        {
            try
            {
                if (sigla != nacionalidade.Sigla) { return BadRequest(); }        
            
                _context.Entry(nacionalidade).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok(nacionalidade);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                               "Ocorreu um problema ao tratar a sua solicitação.");
            }

        }

        [HttpDelete("{sigla}")]
        public ActionResult DeleteNacionalidade(string sigla)
        {
            try
            {
                var nacionalidade = _context.Nacionalidades.FirstOrDefault(n => n.Sigla == sigla);

                if(nacionalidade is null) { return NotFound("Nacionalidade não encontrada para exclusão."); }

                _context.Nacionalidades.Remove(nacionalidade);
                _context.SaveChanges();

                return Ok(nacionalidade);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                               "Ocorreu um problema ao tratar a sua solicitação.");
            }

        }

    }
}
