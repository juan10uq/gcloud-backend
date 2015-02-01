using System;
using System.Linq;
using System.Linq.Expressions;

namespace GCloud.DataAccess.Contract
{
    public interface IReadOnlyRepositoryEagerLoading<TEntity> where TEntity : class
    {
        TEntity Get(Guid id, params  Expression<Func<TEntity, object>>[] includes);
        IQueryable<TEntity> All(params Expression<Func<TEntity, object>>[] includes);
        IQueryable<TEntity> FilterBy(Expression<Func<TEntity, bool>> expression, params  Expression<Func<TEntity, object>>[] includes);
    }
}
