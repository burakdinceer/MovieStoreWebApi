using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreWebApi.Entites
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public int Price { get; set; }
        public bool Active { get; set; } = true;
        public ICollection<MovieRole> movieRoles { get; set; }
        public ICollection<MovieDirector> movieDirectors { get; set; }


    }
}
