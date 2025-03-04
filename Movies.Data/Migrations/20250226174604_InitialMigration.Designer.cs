﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Movies.Data;

#nullable disable

namespace Movies.Data.Migrations
{
    [DbContext(typeof(MoviesDbContext))]
    [Migration("20250226174604_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Movies.Data.Models.Person", b =>
                {
                    b.Property<long>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("PersonId"));

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("PersonId");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            PersonId = 1L,
                            Biography = "Thomas Jeffrey Hanks is an American actor and filmmaker. Known for both his comedic and dramatic roles, Hanks is one of the most popular and recognizable film stars worldwide.",
                            BirthDate = new DateTime(1956, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "USA",
                            Name = "Tom Hanks",
                            Role = 0
                        },
                        new
                        {
                            PersonId = 2L,
                            Biography = "Steven Allan Spielberg is an American film director, producer, and screenwriter. He is considered one of the founding pioneers of the New Hollywood era and one of the most popular directors and producers in film history.",
                            BirthDate = new DateTime(1946, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "USA",
                            Name = "Steven Spielberg",
                            Role = 1
                        },
                        new
                        {
                            PersonId = 3L,
                            Biography = "Mary Louise Streep is an American actress. Often described as the 'best actress of her generation', Streep is particularly known for her versatility and accents.",
                            BirthDate = new DateTime(1949, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "USA",
                            Name = "Meryl Streep",
                            Role = 0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
