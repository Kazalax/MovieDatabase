﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movies.Data.Models;

namespace Movies.Data.Interfaces
{
    public interface IGenreRepository : IBaseRepository<Genre>
    {
        IList<Genre> FindAllByNames(IEnumerable<string> names);
    }
}
