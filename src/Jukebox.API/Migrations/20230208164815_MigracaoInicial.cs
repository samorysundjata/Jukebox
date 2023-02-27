using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jukebox.API.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subgeneros");

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    GeneroId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    GeneroPaiGeneroId = table.Column<int>(type: "INTEGER", nullable: true),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.GeneroId);
                    table.ForeignKey(
                        name: "FK_Generos_Generos_GeneroPaiGeneroId",
                        column: x => x.GeneroPaiGeneroId,
                        principalTable: "Generos",
                        principalColumn: "GeneroId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Generos_GeneroPaiGeneroId",
                table: "Generos",
                column: "GeneroPaiGeneroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.CreateTable(
                name: "Subgeneros",
                columns: table => new
                {
                    SubgeneroId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subgeneros", x => x.SubgeneroId);
                });
        }
    }
}
