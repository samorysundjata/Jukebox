using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jukebox.API.Models
{
    [Table("Generos")]
    public class Genero
    {
        [Key]
        public int GeneroId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        public Genero? GeneroPai { get; set; }

        public ICollection<Genero>? Subgeneros { get; set;}

    }
}
