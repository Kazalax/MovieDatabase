using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movies.Data.Models;

namespace Movies.Data.Interfaces
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        IList<Person> FindAllByIds(IEnumerable<uint> ids);
        IList<Person> GetAll(PersonRole personRole, int page, int pageSize);
    }
}
