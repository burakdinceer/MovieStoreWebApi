using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Entites;

namespace MovieStoreWebApi.DBOperations
{
    public class MovieStoreDbContext : DbContext
    {
        public MovieStoreDbContext(DbContextOptions<MovieStoreDbContext> options ) : base( options )
        {

        }

        public DbSet<Movie> movies { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Director> directors { get; set; }
        public DbSet<Favorite> favorites { get; set; }
        public DbSet<MovieDirector> movieDirectors { get; set; }
        public DbSet<MovieRole> movieRoles { get; set; }
        public DbSet<Purchase> purchases { get; set; }
        public DbSet<Role> roles { get; set; }
    }
}
