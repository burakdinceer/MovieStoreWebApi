using System.Collections.Generic;

namespace MovieStoreWebApi.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetList();
        void DeleteById(int id);
        T GetById(int id);
        T UpdateById(T entity);
        T AddT(T entity);





    }
}
