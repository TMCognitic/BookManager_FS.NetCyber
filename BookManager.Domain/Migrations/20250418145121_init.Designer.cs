﻿// <auto-generated />
using BookManager.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookManager.Domain.Migrations
{
    [DbContext(typeof(BookManagerDbContext))]
    [Migration("20250418145121_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookManager.Entities.Livre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Annee")
                        .HasColumnType("int");

                    b.Property<string>("Auteur")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(75)");

                    b.Property<int>("NbrePage")
                        .HasColumnType("int");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(128)");

                    b.Property<int>("UtilisateurId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UtilisateurId");

                    b.ToTable("Livre", null, t =>
                        {
                            t.HasCheckConstraint("CK_Livre_Annee", "Annee >= 1500");

                            t.HasCheckConstraint("CK_Livre_NbrePage", "NbrePage > 0");
                        });
                });

            modelBuilder.Entity("BookManager.Entities.Utilisateur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(384)");

                    b.Property<string>("Mdp")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(20)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(75)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(75)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("UK_Utilisateur_Email");

                    b.ToTable("Utilisateur", (string)null);
                });

            modelBuilder.Entity("BookManager.Entities.Livre", b =>
                {
                    b.HasOne("BookManager.Entities.Utilisateur", null)
                        .WithMany("Livres")
                        .HasForeignKey("UtilisateurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookManager.Entities.Utilisateur", b =>
                {
                    b.Navigation("Livres");
                });
#pragma warning restore 612, 618
        }
    }
}
