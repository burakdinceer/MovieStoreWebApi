using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreWebApi.Entites
{
    public class MovieRole
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int MovieId { get; set; }
        public virtual Role Role { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
