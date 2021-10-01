using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BL
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> expression);
        T Get(Expression<Func<T, bool>> expression);
        T Find(int id);
        int Add(T entity);
        int Update(T entity);
        int Remove(T entity);
        //Asenkron metotlar
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllByAsync();
    }
}
