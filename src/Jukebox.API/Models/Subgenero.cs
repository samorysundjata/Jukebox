using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jukebox.API.Models
{
    [Table("Subgeneros")]
    public class Subgenero
    {
        [Key]
        public int SubgeneroId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set;}
    }


}
