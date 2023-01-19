using System.ComponentModel.DataAnnotations.Schema;

namespace Jukebox.API.Models
{
    [Table("Musicas")]
    public class Musica
    {
        public int MusicaId { get; set; }

        public string Nome { get; set;  }

        public Artista Interprete { get; set; }

        public ICollection<Artista> Compositores { get; set; }
    }

}
