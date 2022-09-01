﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PortalAnuncios.Data;

#nullable disable

namespace PortalAnuncios.Migrations
{
    [DbContext(typeof(PortalAnunciosContext))]
    partial class PortalAnunciosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ModelagemBd.Anuncio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AnuncianteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnuncianteId");

                    b.ToTable("Anuncio");
                });

            modelBuilder.Entity("ModelagemBd.Candidatura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AnuncioId")
                        .HasColumnType("int");

                    b.Property<int>("CandidatoId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnuncioId");

                    b.HasIndex("CandidatoId");

                    b.ToTable("Candidatura");
                });

            modelBuilder.Entity("ModelagemBd.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("ModelagemBd.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("ModelagemBd.Anuncio", b =>
                {
                    b.HasOne("ModelagemBd.Cliente", "Anunciante")
                        .WithMany("Anuncios")
                        .HasForeignKey("AnuncianteId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Anunciante");
                });

            modelBuilder.Entity("ModelagemBd.Candidatura", b =>
                {
                    b.HasOne("ModelagemBd.Anuncio", "Anuncio")
                        .WithMany()
                        .HasForeignKey("AnuncioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModelagemBd.Cliente", "Candidato")
                        .WithMany("Candidaturas")
                        .HasForeignKey("CandidatoId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Anuncio");

                    b.Navigation("Candidato");
                });

            modelBuilder.Entity("ModelagemBd.Endereco", b =>
                {
                    b.HasOne("ModelagemBd.Cliente", "Cliente")
                        .WithMany("Enderecos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("ModelagemBd.Cliente", b =>
                {
                    b.Navigation("Anuncios");

                    b.Navigation("Candidaturas");

                    b.Navigation("Enderecos");
                });
#pragma warning restore 612, 618
        }
    }
}
