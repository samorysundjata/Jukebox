using Jukebox.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Jukebox.API.Context
{
    //TODO: fazer o script de inserção de dados.
    public class AppDbContext : DbContext
    {
        public DbSet<Musica> Musicas { get; set; }
        public DbSet<Nacionalidade> Nacionalidades { get; set; }        
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Artista> Compositores { get; set; }
        public DbSet<Album> Albuns { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Genero> Subgeneros { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=junkebox.db;Cache=Shared");

    }
}
