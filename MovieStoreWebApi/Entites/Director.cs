using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreWebApi.Entites
{
    public class Director
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Active { get; set; } = true;
        public virtual ICollection<MovieDirector> movieDirectors { get; set; }
    }
}
