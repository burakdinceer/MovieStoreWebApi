using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entites;
using MovieStoreWebApi.Interfaces;

namespace MovieStoreWebApi.Repositories
{
    public class MovieDirectorRepository : GenericRepository<MovieDirector>, IGenericRepository<MovieDirector>
    {
        public MovieDirectorRepository(MovieStoreDbContext context) : base(context)
        {
        }
    }
}
