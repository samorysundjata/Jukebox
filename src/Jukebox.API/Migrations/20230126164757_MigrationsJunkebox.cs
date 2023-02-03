using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jukebox.API.Migrations
{
    /// <inheritdoc />
    public partial class MigrationsJunkebox : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nacionalidades",
                columns: table => new
                {
                    Sigla = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nacionalidades", x => x.Sigla);
                });

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

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    AlbumId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    ArtistaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Lancamento = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.AlbumId);
                });

            migrationBuilder.CreateTable(
                name: "Artistas",
                columns: table => new
                {
                    ArtistaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    NacionalidadeSigla = table.Column<string>(type: "TEXT", nullable: false),
                    MusicaId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artistas", x => x.ArtistaId);
                    table.ForeignKey(
                        name: "FK_Artistas_Nacionalidades_NacionalidadeSigla",
                        column: x => x.NacionalidadeSigla,
                        principalTable: "Nacionalidades",
                        principalColumn: "Sigla",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Musicas",
                columns: table => new
                {
                    MusicaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    InterpreteArtistaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Duracao = table.Column<DateTime>(type: "TEXT", nullable: true),
                    AlbumId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musicas", x => x.MusicaId);
                    table.ForeignKey(
                        name: "FK_Musicas_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "AlbumId");
                    table.ForeignKey(
                        name: "FK_Musicas_Artistas_InterpreteArtistaId",
                        column: x => x.InterpreteArtistaId,
                        principalTable: "Artistas",
                        principalColumn: "ArtistaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ArtistaId",
                table: "Albums",
                column: "ArtistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Artistas_MusicaId",
                table: "Artistas",
                column: "MusicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Artistas_NacionalidadeSigla",
                table: "Artistas",
                column: "NacionalidadeSigla");

            migrationBuilder.CreateIndex(
                name: "IX_Musicas_AlbumId",
                table: "Musicas",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Musicas_InterpreteArtistaId",
                table: "Musicas",
                column: "InterpreteArtistaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Artistas_ArtistaId",
                table: "Albums",
                column: "ArtistaId",
                principalTable: "Artistas",
                principalColumn: "ArtistaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Artistas_Musicas_MusicaId",
                table: "Artistas",
                column: "MusicaId",
                principalTable: "Musicas",
                principalColumn: "MusicaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Artistas_ArtistaId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Musicas_Artistas_InterpreteArtistaId",
                table: "Musicas");

            migrationBuilder.DropTable(
                name: "Subgeneros");

            migrationBuilder.DropTable(
                name: "Artistas");

            migrationBuilder.DropTable(
                name: "Musicas");

            migrationBuilder.DropTable(
                name: "Nacionalidades");

            migrationBuilder.DropTable(
                name: "Albums");
        }
    }
}
