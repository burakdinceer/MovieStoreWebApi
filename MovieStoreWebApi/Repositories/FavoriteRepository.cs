using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entites;
using MovieStoreWebApi.Interfaces;

namespace MovieStoreWebApi.Repositories
{
    public class FavoriteRepository : GenericRepository<Favorite>, IGenericRepository<Favorite>
    {
        public FavoriteRepository(MovieStoreDbContext context) : base(context)
        {
        }
    }
}
