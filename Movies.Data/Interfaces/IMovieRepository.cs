using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movies.Data.Models;

namespace Movies.Data.Interfaces
{
    public interface IMovieRepository : IBaseRepository<Movie>
    {
        IList<Movie> GetAll(uint? directorId = null, uint? actorId = null, string? genre = null, int? fromYear = null, int? toYear = null, int? limit = null);
    }
}
