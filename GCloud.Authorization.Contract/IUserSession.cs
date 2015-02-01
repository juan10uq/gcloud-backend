using System;
using System.Data;
using System.Security.Principal;
using GCloud.Models;

namespace GCloud.Authorization.Contract
{
    public interface IUserSession
    {
        /// <summary>
        /// This indicates the tenant which the current user belongs to
        /// </summary>
        Guid TenantId { get; }
        /// <summary>
        /// Supertenant is a super admin, can see all the tenants data
        /// </summary>
        bool IsSuperTenant { get; }

        /// <summary>
        /// Operation the user wants to execute
        /// </summary>
        string OperationToExecute { get; set; }

        /// <summary>
        /// Resource over the operation will be applied
        /// </summary>
        Guid ResourceIdOverApplingOperation { get; set; }

        /// <summary>
        /// User Id
        /// </summary>
        Guid UserId { get; }

        /// <summary>
        /// User Name
        /// </summary>
        string UserName { get; }

        /// <summary>
        /// Name
        /// </summary>
        string FirstName { get; }

        /// <summary>
        /// Last Name
        /// </summary>
        string LastName { get; }

        /// <summary>
        /// Email
        /// </summary>
        string Email { get; }

        /// <summary>
        /// Check if the user has permission to execute a operation
        /// </summary>
        /// <param name="principal"></param>
        /// <param name="resourceId"></param>
        /// <param name="operation"></param>
        /// <returns></returns>
        bool CheckAccess(IPrincipal principal, Guid resourceId, string operation);
    }
}
