using System.ComponentModel.DataAnnotations.Schema;

namespace Jukebox.API.Models
{
    [Table("Albums")]
    public class Album
    {
        public int AlbumId { get; set; }
        
        public string Nome { get; set; }

        public Artista Artista { get; set; }

        public DateTime Lancamento { get; set; }

        public ICollection<Musica> Musicas { get; set; }

    }


}
