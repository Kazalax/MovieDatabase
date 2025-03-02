using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movies.Data.Interfaces;
using Movies.Data.Models;

namespace Movies.Data.Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(MoviesDbContext moviesDbContext) : base(moviesDbContext)
        {
        }
        public IList<Person> GetAll(PersonRole personRole, int page, int pageSize)
        {
            return dbSet
                .Where(p => p.Role == personRole)
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public IList<Person> FindAllByIds(IEnumerable<uint> ids)
        {
            return dbSet.Where(p => ids.Contains(p.PersonId)).ToList();
        }
    }
}
