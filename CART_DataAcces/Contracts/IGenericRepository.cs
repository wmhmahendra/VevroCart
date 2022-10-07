using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CART_DataAcces.Contracts
{
    class IGenericRepository
    {

    }
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>
        /// Returns the all records of the supplied object.
        /// </returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Finds the by.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>
        /// Returns the relevant queried predicate.
        /// </returns>
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Returns the first entity that matches the predicate
        /// </summary>
        /// <param name="predicate">The filter clause</param>
        /// <returns>An entity matching the predicate</returns>
        T First(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Returns the first entity that matches the predicate else null
        /// </summary>
        /// <param name="predicate">The filter clause</param>
        /// <returns>An entity matching the predicate else null</returns>
        T FirstOrDefault(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Add(T entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(T entity);

        /// <summary>
        /// Deletes the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>
        /// Return No of records that deleted.
        /// </returns>
        int Delete(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Edits the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Edit(T entity);

        /// <summary>
        /// Saves this instance.
        /// </summary>
        int Save();
    }
}
