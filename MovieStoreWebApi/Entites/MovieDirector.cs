
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreWebApi.Entites
{
    public class MovieDirector
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int DirectorId { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Director Director { get; set; }


    }
}
