using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jukebox.API.Models
{
    [Table("Nacionalidades")]
    public class Nacionalidade
    {
        [Key]
        [Required]
        public string Sigla { get; set;}

        [Required]
        [StringLength(100)]
        public string Nome { get; set;}
    }


}
