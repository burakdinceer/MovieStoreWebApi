using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entites;
using MovieStoreWebApi.Interfaces;

namespace MovieStoreWebApi.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, IGenericRepository<Customer>
    {
        public CustomerRepository(MovieStoreDbContext context) : base(context)
        {
        }
    }
}
