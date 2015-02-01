using System;
using System.Threading.Tasks;

namespace GCloud.DataAccess.Contract
{
    /// Maintains a list of objects affected by a business transaction and coordinates the writing out of changes and the resolution of concurrency problems
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commit all changes in the context to the database
        /// </summary>
        int SaveChanges();

        /// <summary>
        /// Asynchronously saves all changes made in this context to the underlying database.
        /// </summary>
        Task<int> SaveChangesAsync();
    }
}
