using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movies.Data.Interfaces;
using Movies.Data.Models;

namespace Movies.Data.Repositories
{
    public class MovieRepository :BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MoviesDbContext moviesDbContext) : base(moviesDbContext)
        {
        }

        public IList<Movie> GetAll(
            uint? directorId = null,
            uint? actorId = null,
            string? genre = null,
            int? fromYear = null,
            int? toYear = null,
            int? limit = null)
        {
            IQueryable<Movie> query = dbSet;
            if (fromYear is not null)
                query = query.Where(m => m.Year >= fromYear.Value);
            if (toYear is not null)
                query = query.Where(m => m.Year <= toYear.Value);
            if(directorId is not null)
                query = query.Where(m => m.DirectorId == directorId);
            if (actorId is not null)
                query = query.Where(m => m.Actors.Any(a => a.PersonId == actorId));
            if (genre is not null)
                query = query.Where(m => m.Genres.Any(g => g.Name == genre));
            if (limit is not null && limit >=0)
                query = query.Take(limit.Value);

            return query.ToList();

        }
    }
}
