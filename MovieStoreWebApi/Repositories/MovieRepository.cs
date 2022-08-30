using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entites;
using MovieStoreWebApi.Interfaces;

namespace MovieStoreWebApi.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IGenericRepository<Movie>
    {
        public MovieRepository(MovieStoreDbContext context) : base(context)
        {
        }
    }
}
