using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

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
           _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void DeleteById(int id)
        {
          
            _context.SaveChanges();

        }

        public T GetById(int id)
        {
           return _context.Set<T>().Find(id);
            
        }

        public List<T> GetList()
        {
            var list = _context.Set<T>().ToList();
            return list;
        }

        public T UpdateById(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }
    }
}
