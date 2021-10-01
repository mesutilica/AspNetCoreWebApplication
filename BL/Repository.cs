using DAL;
using Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Repository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private DataBaseContext context;
        private DbSet<T> _objectSet;

        public Repository()
        {
            if (context == null)
            {
                context = new DataBaseContext();
                _objectSet = context.Set<T>();
            }
        }

        public int Add(T entity)
        {
            _objectSet.Add(entity);
            return context.SaveChanges();
        }

        public T Find(int id)
        {
            return _objectSet.Find(id);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return _objectSet.FirstOrDefault(expression);
        }

        public List<T> GetAll()
        {
            return _objectSet.ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return _objectSet.Where(expression).ToList();
        }

        public async Task<IEnumerable<T>> GetAllByAsync()
        {
            return await _objectSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _objectSet.FindAsync(id);
        }

        public int Remove(T entity)
        {
            _objectSet.Remove(entity);
            return context.SaveChanges();
        }

        public int Update(T entity)
        {
            _objectSet.Update(entity);
            return context.SaveChanges();
        }
    }
}
