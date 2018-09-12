using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AES.Data
{
    public interface IRepository<T>
    {
        /// <summary>
        /// Get Items By Identifier
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<List<T>> GetByIdAsync(string Id);

        
        /// <summary>
        /// Search Item By Search Text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        Task<T> SearchByTextAsync(string text);

        /// <summary>
        /// Insert Item
        /// </summary>
        /// <param name="entity"></param>
        void Insert(T entity);

        /// <summary>
        /// Insert Items
        /// </summary>
        /// <param name="entities"></param>
        void Insert(IEnumerable<T> entities);

        /// <summary>
        /// Update Item
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// Update Items
        /// </summary>
        /// <param name="entities"></param>
        void Update(IEnumerable<T> entities);

        /// <summary>
        /// Delete Item
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// Delete Items
        /// </summary>
        /// <param name="entities"></param>
        void Delete(IEnumerable<T> entities);

        /// <summary>
        /// Gets a table
        /// </summary>
        IQueryable<T> Table { get; }
    }

}
