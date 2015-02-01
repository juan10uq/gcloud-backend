using System;
using System.Collections.Generic;
using Breeze.ContextProvider;

namespace GCloud.Authorization.Contract
{
    public interface IAuthRuleManager
    {
        bool Validate(string operation, Guid resourceId, Dictionary<Type, List<EntityInfo>> saveMap);
    }
}
