using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jukebox.API.Models
{
    [Table("Musicas")]
    public class Musica
    {
        [Key]
        public int MusicaId { get; set; }

        [Required]
        [StringLength(80)]
        public string Nome { get; set;  }

        [Required]
        public Artista Interprete { get; set; }

        public DateTime? Duracao { get; set; }

        public ICollection<Artista>? Compositores { get; set; }
    }

}
