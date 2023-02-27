using Jukebox.API.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

#nullable disable

namespace Jukebox.API.Migrations
{
    /// <inheritdoc />
    public partial class PopulaGeneros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into generos(Nome, Descricao) Values('Jazz', 'Gênero pai jazz')");
            migrationBuilder.Sql("insert into generos(Nome, Descricao) Values('Rock', 'Gênero pai rock')");
            migrationBuilder.Sql("insert into generos(Nome, Descricao) Values('Clássico', 'Gênero pai clássico')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from generos");
        }
    }
}
