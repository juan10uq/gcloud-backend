using System;
using System.Collections.Generic;
using Breeze.ContextProvider;

namespace GCloud.Core.Contract.Breeze
{
    public interface IBreezeSaveService
    {
        Dictionary<Type, List<EntityInfo>> Execute(Dictionary<Type, List<EntityInfo>> saveMap);
    }
}
