using System;
using System.Collections.Generic;
using System.Linq;
using GCloud.DataAccess.Contract;
using GCloud.Models;
using  GCloud.Authorization.Contract;
namespace GCloud.Authorization
{
   /* public class ResourceService : IResourceService
    {
         /// <summary>
        /// DB context
        /// </summary>
        private readonly IGCloudUnitOfWork _gCloudUnitOfWork;
        public ResourceService(IGCloudUnitOfWork gCloudUnitOfWork)
        {
            _gCloudUnitOfWork = gCloudUnitOfWork;
        }

        public List<string> GetOperationsByUserName(string userName)
        {
            var operationToRoles = new List<OperationToRol>();
            var user = _gCloudUnitOfWork.UserRepository.FindBy(u => u.UserName.Equals(userName));
            var roles = user.UserRoles.Select(r => r.RolId).ToArray();

            foreach (var operationRoleFiltered in roles.Select(id => _gCloudUnitOfWork.OperationToRolesRepository.FilterBy(o => o.RolId.Equals(id), rol => rol.Operation, rol => rol.Operation.Resource).ToList()))
            {
                operationToRoles.AddRange(operationRoleFiltered);
            }

            var result = operationToRoles.Select(operationTorole => string.Format("{0}_{1}", operationTorole.Operation.Resource.Name, operationTorole.Operation.Name)).ToList();

            return result.Distinct().ToList();
        }


        public bool ExistResource(Guid id)
        {
            var resource = _gCloudUnitOfWork.ResourceRepository.Get(id);
            return resource != null;
        }

        public bool Authorize(string userName, Guid resourceId, string operation)
        {
            if (userName == null || userName.Equals(string.Empty))
                throw new ArgumentNullException("userName");
            if (resourceId == (Guid.Empty))
                throw new ArgumentException("resourceId must has a value greater than -1");
            if (operation == null || operation.Equals(string.Empty))
                throw new ArgumentException("operation must has a value different than none");

            var user = _gCloudUnitOfWork.UserRepository.FilterBy(u => u.UserName.Equals(userName), u => u.UserRoles).First();
            var roles = user.UserRoles.Select(r => r.RolId).ToArray();
            return Authorize(resourceId, operation, roles);
        }


        public bool Authorize(Guid resourceId, string operation, Guid[] roles)
        {
            return roles.Select(roleId => _gCloudUnitOfWork.OperationToRolesRepository.FilterBy(o => o.RolId.Equals(roleId) && o.Operation.ResourceId == resourceId && (o.Operation.Name.Equals(operation))).Count()).Any(count => count > 0);
        }

        public bool Authorize(string userName, Guid[] resourceIds, string[] operations)
        {
            if (userName == null || userName.Equals(string.Empty))
                throw new ArgumentNullException("userName");
            if (resourceIds == null || !resourceIds.Any())
                throw new ArgumentException("resourceIds has not elements");
            if (operations == null || !operations.Any())
                throw new ArgumentException("operations has not elements");

            var user = _gCloudUnitOfWork.UserRepository.FilterBy(u => u.UserName.Equals(userName), u => u.UserRoles).First();
            var roles = user.UserRoles.Select(r => r.RolId).ToArray();
            return Authorize(resourceIds, operations, roles);
        }

        public bool Authorize(Guid[] resourceIds, string[] operations, Guid[] roles)
        {
            var authorized = false;
            foreach (var roleId in roles)
            {
                if (authorized)
                {
                    break;
                }
                foreach (var resourceId in resourceIds)
                {
                    if (operations.Any(operationName => _gCloudUnitOfWork.OperationToRolesRepository.FilterBy(o => o.RolId.Equals(roleId) && o.Operation.ResourceId.Equals(resourceId) && o.Operation.Name.Equals(operationName)).Any()))
                    {
                        authorized = true;
                        break;
                    }
                }
            }
            return authorized;
        }
        
    }*/
}
