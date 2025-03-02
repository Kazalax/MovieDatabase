using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Movies.Data.Models;

namespace Movies.Data
{
    public class MoviesDbContext : DbContext
    {
        public DbSet<Movie>? Movies { get; set; }
        public DbSet<Person>? People { get; set; }
        public DbSet<Genre>? Genres { get; set; }

        public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Movie>()
                .HasOne(m => m.Director)
                .WithMany(p => p.MoviesAsDirector);

            modelBuilder
                .Entity<Movie>()
                .HasMany(m => m.Actors)
                .WithMany(p => p.MoviesAsActor)
                .UsingEntity(j => j.ToTable("MovieActors"));   
            IEnumerable<IMutableForeignKey> cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(type => type.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade); 

            AddTestingData(modelBuilder);
        }

        private void AddTestingData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    PersonId = 1,
                    Name = "Tom Hanks",
                    BirthDate = new DateTime(1956, 7, 9),
                    Country = "USA",
                    Biography = "Thomas Jeffrey Hanks is an American actor and filmmaker. Known for both his comedic and dramatic roles, Hanks is one of the most popular and recognizable film stars worldwide.",
                    Role = PersonRole.Actor
                },
                new Person
                {
                    PersonId = 2,
                    Name = "Steven Spielberg",
                    BirthDate = new DateTime(1946, 12, 18),
                    Country = "USA",
                    Biography = "Steven Allan Spielberg is an American film director, producer, and screenwriter. He is considered one of the founding pioneers of the New Hollywood era and one of the most popular directors and producers in film history.",
                    Role = PersonRole.Director
                },
                new Person
                {
                    PersonId = 3,
                    Name = "Meryl Streep",
                    BirthDate = new DateTime(1949, 6, 22),
                    Country = "USA",
                    Biography = "Mary Louise Streep is an American actress. Often described as the 'best actress of her generation', Streep is particularly known for her versatility and accents.",
                    Role = PersonRole.Actor
                });
            modelBuilder.Entity<Genre>().HasData(
               new Genre { GenreId = 1, Name = "sci-fi" },
               new Genre { GenreId = 2, Name = "adventure" },
               new Genre { GenreId = 3, Name = "action" },
               new Genre { GenreId = 4, Name = "romantic" },
               new Genre { GenreId = 5, Name = "animated" },
               new Genre { GenreId = 6, Name = "comedy" });
        }
    }
}
