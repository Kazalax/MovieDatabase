﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Movies.Data.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public uint GenreId { get; set; }
        [Required, MinLength(3)]
        public string Name { get; set; } = "";  

        public virtual List<Movie> Movies { get; set; } = new List<Movie>();
    }
}
