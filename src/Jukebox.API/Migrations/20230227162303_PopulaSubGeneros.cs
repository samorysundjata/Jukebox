using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jukebox.API.Migrations
{
    /// <inheritdoc />
    public partial class PopulaSubGeneros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("insert into generos(Nome, GeneroPaiGeneroId, Descricao) Values('Fusion', 1, 'Subgênero do Jazz que se funde com o Rock')");
            mb.Sql("insert into generos(Nome, Descricao) Values('Blues', 'Blues a música padrão negra norte-americana')");
            mb.Sql("insert into generos(Nome, GeneroPaiGeneroId, Descricao) Values('Hard Rock', 2, 'Subgênero do Rock mais pesado')");
            mb.Sql("insert into generos(Nome, GeneroPaiGeneroId, Descricao) Values('Heavy Metal', 2, 'Subgênero do Rock mais pesado ainda')");
            mb.Sql("insert into generos(Nome, GeneroPaiGeneroId, Descricao) Values('Glam Rock', 2, 'Subgênero do Rock mais leve')");
            mb.Sql("insert into generos(Nome, GeneroPaiGeneroId, Descricao) Values('Barroco', 3, 'Subgênero do Clássico')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("delete from generos");
        }
    }
}
