using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jukebox.API.Models
{
    [Table("Artistas")]
    public class Artista
    {
        [Key]
        public int ArtistaId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        public Nacionalidade Nacionalidade { get; set; }
    }
}
