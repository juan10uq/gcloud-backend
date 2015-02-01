using System;
using System.Collections.Generic;
using Breeze.ContextProvider;

namespace GCloud.Authorization.Contract
{
    public interface IRuleActivity
    {
        bool IsMatch(Guid resourceId, string operation);
        bool Validate(Dictionary<Type, List<EntityInfo>> saveMap);
    }
}
