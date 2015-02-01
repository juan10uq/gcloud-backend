using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace GCloud.DataAccess.Contract
{
    public interface IReadOnlyRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Gets all objects from database
        /// </summary>
        IQueryable<TEntity> All();

        /// <summary>
        /// Find object by key
        /// </summary>
        /// <param name="id">Specified the search keys</param>
        /// <returns></returns>
        TEntity Get(Guid id);
    }
}
