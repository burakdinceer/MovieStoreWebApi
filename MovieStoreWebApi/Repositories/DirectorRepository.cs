using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entites;
using MovieStoreWebApi.Interfaces;

namespace MovieStoreWebApi.Repositories
{
    public class DirectorRepository : GenericRepository<Director>, IGenericRepository<Director>
    {
        public DirectorRepository(MovieStoreDbContext context) : base(context)
        {
        }
    }
}
