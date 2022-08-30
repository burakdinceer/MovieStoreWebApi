using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entites;
using MovieStoreWebApi.Interfaces;

namespace MovieStoreWebApi.Repositories
{
    public class PurchaseRepository : GenericRepository<Purchase>, IGenericRepository<Purchase>
    {
        public PurchaseRepository(MovieStoreDbContext context) : base(context)
        {
        }
    }
}
