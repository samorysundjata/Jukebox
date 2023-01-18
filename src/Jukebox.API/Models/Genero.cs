namespace Jukebox.API.Models
{
    public class Genero
    {
        public int GeneroId { get; set; }

        public string Nome { get; set; }

        public ICollection<Subgenero> Subgeneros { get; set;}

    }

    public class Subgenero
    {
        public int SubgeneroId { get; set; }
        public string Nome { get; set;}
    }


}
