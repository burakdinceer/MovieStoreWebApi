using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Interfaces;
using System.Collections.Generic;

namespace MovieStoreWebApi.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        private readonly MovieStoreDbContext _context;
        public GenericRepository(MovieStoreDbContext context)
        {
            _context = context;
        }        

        public T AddT(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new System.NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<T> GetList()
        {
            throw new System.NotImplementedException();
        }

        public T UpdateById(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
