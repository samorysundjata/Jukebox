using System.ComponentModel.DataAnnotations.Schema;

namespace Jukebox.API.Models
{
    [Table("Generos")]
    public class Genero
    {
        public int GeneroId { get; set; }

        public string Nome { get; set; }

        public ICollection<Subgenero>? Subgeneros { get; set;}

    }
}
