using System;
using System.Collections.Generic;
using Breeze.ContextProvider;

namespace GCloud.Core.Contract
{
    public interface IGCloudEntitySaveGuard
    {
        bool BeforeSaveEntity(EntityInfo arg);
        Dictionary<Type, List<EntityInfo>> BeforeSaveEntities(Dictionary<Type, List<EntityInfo>> saveMap);
    }
}
