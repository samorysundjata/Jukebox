using System.ComponentModel.DataAnnotations.Schema;

namespace Jukebox.API.Models
{
    [Table("Subgeneros")]
    public class Subgenero
    {
        public int SubgeneroId { get; set; }

        public string Nome { get; set;}
    }


}
