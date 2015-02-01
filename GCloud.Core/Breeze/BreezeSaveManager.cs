using System;
using System.Collections.Generic;
using Breeze.ContextProvider;
using GCloud.Core.Contract.Breeze;
using GCloud.Models;

namespace GCloud.Core.Breeze
{
    public class BreezeSaveManager : IBreezeSaveManager
    {
        private readonly IBreezeServiceFactory _breezeServiceFactory;

        public BreezeSaveManager(IBreezeServiceFactory breezeServiceFactory)
        {
            _breezeServiceFactory = breezeServiceFactory;
        }

        public Dictionary<Type, List<EntityInfo>> Execute(string operation, Guid resourseId, Dictionary<Type, List<EntityInfo>> saveMap)
        {
            var breezeService = _breezeServiceFactory.Get(resourseId, operation);
            return breezeService != null ? breezeService.Execute(saveMap) : saveMap;
        }
    }
}
