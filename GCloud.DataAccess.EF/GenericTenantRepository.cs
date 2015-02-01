using System;
using System.Data.Entity;
using System.Linq.Expressions;
using GCloud.Authorization.Contract;
using GCloud.Models;
using GCloud.Models.Contract;

namespace GCloud.DataAccess.EF
{
    /// <summary>
    /// General Repository Pattern
    /// </summary>
    /// <typeparam name="TEntity">Data Object</typeparam>
    public class GenericTenantRepository<TEntity> : BaseGenericRepository<TEntity> where TEntity : class, IEntity, ILogicalDelete, IAudit, ITenant
    {
        public GenericTenantRepository(DbContext contextDb, IUserSession userSession)
            : base(contextDb, userSession)
        {

        }

        #region ITenant interface

        protected override void SetTenant(TEntity entity)
        {
            entity.TenantId = UserSession.TenantId;
        }

        protected override Expression<Func<TEntity, bool>> FilterByTenant()
        {
            Expression<Func<TEntity, bool>> tenantFiler = e => true;
            if (!UserSession.IsSuperTenant)
            {
                tenantFiler = e => e.TenantId == UserSession.TenantId;
            }
            return tenantFiler;
        }

        #endregion

        #region ILogicalDelete interface

        protected override void SetActive(TEntity entity, bool value)
        {
            entity.Active = value;
        }

        protected override Expression<Func<TEntity, bool>> FilterByActive(bool value)
        {
            Expression<Func<TEntity, bool>> activeFilter = t => t.Active;
            return activeFilter;
        }

        #endregion

        #region IAudit interface

        protected override TEntity SetAuditAdd(TEntity entity)
        {
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;
            entity.CreatedBy = UserSession.UserId;
            entity.UpdatedBy = UserSession.UserId;
            return entity;
        }

        protected override TEntity SetAuditUpdate(TEntity entity)
        {
            entity.UpdateDate = DateTime.UtcNow;
            entity.UpdatedBy = UserSession.UserId;
            return entity;
        }

        #endregion
    }
}
