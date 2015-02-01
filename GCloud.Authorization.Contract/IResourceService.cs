using System;
using System.Collections.Generic;

namespace GCloud.Authorization.Contract
{
    public interface IResourceService
    {
        List<string> GetOperationsByUserName(string userName);
        bool ExistResource(Guid id);
        bool Authorize(string userName, Guid resourceId, string operation);
        bool Authorize(Guid resourceId, string operation, Guid[] roles);
    }
}
