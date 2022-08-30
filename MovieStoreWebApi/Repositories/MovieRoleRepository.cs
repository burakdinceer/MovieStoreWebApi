using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entites;
using MovieStoreWebApi.Interfaces;

namespace MovieStoreWebApi.Repositories
{
    public class MovieRoleRepository : GenericRepository<MovieRole>, IGenericRepository<MovieRole>
    {
        public MovieRoleRepository(MovieStoreDbContext context) : base(context)
        {
        }
    }
}
