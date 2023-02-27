﻿// <auto-generated />
using System;
using Jukebox.API.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Jukebox.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("Jukebox.API.Models.Album", b =>
                {
                    b.Property<int>("AlbumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArtistaId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Lancamento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.HasKey("AlbumId");

                    b.HasIndex("ArtistaId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("Jukebox.API.Models.Artista", b =>
                {
                    b.Property<int>("ArtistaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MusicaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NacionalidadeSigla")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("ArtistaId");

                    b.HasIndex("MusicaId");

                    b.HasIndex("NacionalidadeSigla");

                    b.ToTable("Artistas");
                });

            modelBuilder.Entity("Jukebox.API.Models.Genero", b =>
                {
                    b.Property<int>("GeneroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int?>("GeneroPaiGeneroId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("GeneroId");

                    b.HasIndex("GeneroPaiGeneroId");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("Jukebox.API.Models.Musica", b =>
                {
                    b.Property<int>("MusicaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AlbumId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Duracao")
                        .HasColumnType("TEXT");

                    b.Property<int>("InterpreteArtistaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.HasKey("MusicaId");

                    b.HasIndex("AlbumId");

                    b.HasIndex("InterpreteArtistaId");

                    b.ToTable("Musicas");
                });

            modelBuilder.Entity("Jukebox.API.Models.Nacionalidade", b =>
                {
                    b.Property<string>("Sigla")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Sigla");

                    b.ToTable("Nacionalidades");
                });

            modelBuilder.Entity("Jukebox.API.Models.Album", b =>
                {
                    b.HasOne("Jukebox.API.Models.Artista", "Artista")
                        .WithMany()
                        .HasForeignKey("ArtistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artista");
                });

            modelBuilder.Entity("Jukebox.API.Models.Artista", b =>
                {
                    b.HasOne("Jukebox.API.Models.Musica", null)
                        .WithMany("Compositores")
                        .HasForeignKey("MusicaId");

                    b.HasOne("Jukebox.API.Models.Nacionalidade", "Nacionalidade")
                        .WithMany()
                        .HasForeignKey("NacionalidadeSigla")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nacionalidade");
                });

            modelBuilder.Entity("Jukebox.API.Models.Genero", b =>
                {
                    b.HasOne("Jukebox.API.Models.Genero", "GeneroPai")
                        .WithMany("Subgeneros")
                        .HasForeignKey("GeneroPaiGeneroId");

                    b.Navigation("GeneroPai");
                });

            modelBuilder.Entity("Jukebox.API.Models.Musica", b =>
                {
                    b.HasOne("Jukebox.API.Models.Album", null)
                        .WithMany("Musicas")
                        .HasForeignKey("AlbumId");

                    b.HasOne("Jukebox.API.Models.Artista", "Interprete")
                        .WithMany()
                        .HasForeignKey("InterpreteArtistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Interprete");
                });

            modelBuilder.Entity("Jukebox.API.Models.Album", b =>
                {
                    b.Navigation("Musicas");
                });

            modelBuilder.Entity("Jukebox.API.Models.Genero", b =>
                {
                    b.Navigation("Subgeneros");
                });

            modelBuilder.Entity("Jukebox.API.Models.Musica", b =>
                {
                    b.Navigation("Compositores");
                });
#pragma warning restore 612, 618
        }
    }
}
