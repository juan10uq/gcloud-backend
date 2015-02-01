using System;
using System.Collections.Generic;
using Breeze.ContextProvider;
using GCloud.Models;

namespace GCloud.Core.Contract.Breeze
{
    public interface IBreezeSaveManager
    {
        Dictionary<Type, List<EntityInfo>> Execute(string operation, Guid resourceId, Dictionary<Type, List<EntityInfo>> saveMap);
    }
}
