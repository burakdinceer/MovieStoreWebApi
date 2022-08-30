using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entites;
using MovieStoreWebApi.Interfaces;

namespace MovieStoreWebApi.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IGenericRepository<Role>
    {
        public RoleRepository(MovieStoreDbContext context) : base(context)
        {
        }
    }
}
