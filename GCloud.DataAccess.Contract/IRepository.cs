using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GCloud.DataAccess.Contract
{
    public interface IRepository<TEntity> : IDisposable, IReadOnlyRepositoryEagerLoading<TEntity>, IReadOnlyRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);
        int Add(IEnumerable<TEntity> items);
        int Update(TEntity entity);

        /// <summary>
        /// Delete the object from database.
        /// </summary>
        /// <param name="entity">Specified a existing object to delete.</param>
        /// <returns>True if the object was deleted</returns>
        int Delete(TEntity entity);

        /// <summary>
        /// Delete the object from database.
        /// </summary>
        /// <param name="id">Specified a existing object to delete.</param>
        /// <returns>True if the object was deleted</returns>
        int Delete(Guid id);

        /// <summary>
        /// Delete objects from database by specified filter expression.
        /// </summary>
        /// <param name="entities">Entities to be deleted</param>
        /// <returns>Number of entities removed</returns>
        int Delete(IEnumerable<TEntity> entities);

        /// <summary>
        /// Delete objects from database by specified filter expression.
        /// </summary>
        /// <param name="predicate"></param>
        int Delete(Expression<Func<TEntity, bool>> predicate);

    }
}
