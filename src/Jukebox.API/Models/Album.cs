using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jukebox.API.Models
{
    [Table("Albums")]
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }

        [Required]
        [StringLength(80)]
        public string Nome { get; set; }

        [Required]
        public Artista Artista { get; set; }

        public DateTime Lancamento { get; set; }

        [Required]
        public ICollection<Musica> Musicas { get; set; }

    }


}
