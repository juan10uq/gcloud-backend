using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using GCloud.Authorization.Contract;

namespace GCloud.WebApi.Common.Security
{
    public class UserSession : IUserSession
    {
       // private readonly IResourceService _resourceService;

        public UserSession(/*IResourceService resourceService*/)
        {
            //_resourceService = resourceService;
            var principal = Thread.CurrentPrincipal as ClaimsPrincipal;
            if (principal == null)
                throw new NullReferenceException("principal");

           /* UserId = Int32.Parse(principal.FindFirst(ClaimTypes.Sid).Value);
            FirstName = principal.FindFirst(ClaimTypes.GivenName).Value;
            LastName = principal.FindFirst( ClaimTypes.Surname).Value;
            UserName = principal.FindFirst(ClaimTypes.Name).Value;
            Email = principal.FindFirst(ClaimTypes.Email).Value;
            TenantId = Int32.Parse(principal.FindFirst(c => c.Type.Equals("tenantid", StringComparison.OrdinalIgnoreCase)).Value);*/
            TenantId = new Guid("906E5A5D-713B-E411-B667-D43D7EE1CDFA");
            IsSuperTenant = false;
            ResourceIdOverApplingOperation = Guid.Empty;
            OperationToExecute = string.Empty;
        }


        /// <summary>
        /// User Id
        /// </summary>
        public Guid UserId { get; private set; }

        /// <summary>
        /// This indicates the tenant which the current user belongs to
        /// </summary>
        public Guid TenantId { get; private set; }
        /// <summary>
        /// Supertenant is a super admin, can see all the tenants data
        /// </summary>
        public bool IsSuperTenant { get; private set; }

        /// <summary>
        /// Operation the user wants to execute
        /// </summary>
        public string OperationToExecute { get; set; }

        /// <summary>
        /// Resource over the operation will be applied
        /// </summary>
        public Guid ResourceIdOverApplingOperation { get; set; }

        /// <summary>
        /// User Name
        /// </summary>
        public string UserName { get; private set; }

        /// <summary>
        /// Name
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// Last Name
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Check if the user has permission to execute a operation
        /// </summary>
        /// <param name="principal"></param>
        /// <param name="resourceId"></param>
        /// <param name="operation"></param>
        /// <returns></returns>
        public bool CheckAccess(IPrincipal principal, Guid resourceId, string operation)
        {
            OperationToExecute = operation;
            ResourceIdOverApplingOperation = resourceId;
            if (principal.Identity.IsAuthenticated)
            {
                //  return _resourceService.Authorize(UserName, resourceId, operation);
                return true;
            }
            throw new UnauthorizedAccessException("Inventory Unauthorized Access");
        }

    }
}
