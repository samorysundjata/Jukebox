using System.ComponentModel.DataAnnotations.Schema;

namespace Jukebox.API.Models
{
    [Table("Artistas")]
    public class Artista
    {
        public int ArtistaId { get; set; }
        
        public string Nome { get; set; }

        public Nacionalidade Nacionalidade { get; set; }
    }
}
