using CART_DataAcces.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CART_DataAcces.Implementation
{
    public abstract class GenericRepository<C, T> :
    IGenericRepository<T>
       where T : class
       where C : DbContext, new()
    {
        private C _entities = new C();

        /// <summary>
        /// The database context for the repository
        /// </summary>
        public C Context
        {
            get { return _entities; }
            set { _entities = value; }
        }

        public void Add(T entity)
        {
            _entities.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _entities.Set<T>().Remove(entity);
        }

        public int Delete(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _entities.Set<T>().Where(predicate);

            int deleteCount = query.Count();

            foreach (T item in query)
            {
                _entities.Set<T>().Remove(item);
            }

            //this.Save();

            return deleteCount;
        }

        public void Edit(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _entities.Set<T>().Where(predicate);
            return query;
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            return _entities.Set<T>().First(predicate);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _entities.Set<T>().FirstOrDefault(predicate);
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> query = _entities.Set<T>();
            return query;
        }

        public int Save()
        {
            return _entities.SaveChanges();
        }
    }
}
