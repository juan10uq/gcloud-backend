using System;
using System.Collections.Generic;
using Breeze.ContextProvider;
using GCloud.Authorization.Contract;
using GCloud.Common.Contract;
using GCloud.Core.Contract;
using GCloud.Core.Contract.Breeze;
using GCloud.Models;

namespace GCloud.Core.Breeze
{
    public class GCloudEntitySaveGuard : IGCloudEntitySaveGuard
    {
        private readonly IAuthRuleManager _authRuleManager;
        private readonly IBreezeSaveManager _breezeSaveManager;
        private readonly IUserSession _userSession;
        private readonly IDateTime _dateTime;

        public GCloudEntitySaveGuard(IAuthRuleManager authRuleManager, IUserSession userContext,
            IBreezeSaveManager breezeSaveManager, IDateTime dateTime)
        {
            _authRuleManager = authRuleManager;
            _userSession = userContext;
            _breezeSaveManager = breezeSaveManager;
            _dateTime = dateTime;
        }

        public bool BeforeSaveEntity(EntityInfo entityInfo)
        {
            if (entityInfo.Entity.GetType().BaseType == typeof (EntityBase) &&
                entityInfo.EntityState == EntityState.Added)
            {
                ((EntityBase) entityInfo.Entity).TenantId = _userSession.TenantId;
                ((EntityBase) entityInfo.Entity).Active = true;
                ((EntityBase)entityInfo.Entity).CreateDate = _dateTime.UtcNow;
                ((EntityBase)entityInfo.Entity).UpdateDate = _dateTime.UtcNow;
                ((EntityBase) entityInfo.Entity).CreatedBy = _userSession.UserId;
                ((EntityBase) entityInfo.Entity).UpdatedBy = _userSession.UserId;

                entityInfo.OriginalValuesMap["TenantId"] = null;
                entityInfo.OriginalValuesMap["Active"] = null;
                entityInfo.OriginalValuesMap["CreateDate"] = null;
                entityInfo.OriginalValuesMap["UpdateDate"] = null;
                entityInfo.OriginalValuesMap["CreatedBy"] = null;
                entityInfo.OriginalValuesMap["UpdatedBy"] = null;
            }
            else if (entityInfo.Entity.GetType().BaseType == typeof (EntityBase) &&
                     entityInfo.EntityState == EntityState.Modified)
            {
                ((EntityBase) entityInfo.Entity).UpdatedBy = _userSession.UserId;
                ((EntityBase)entityInfo.Entity).UpdateDate = _dateTime.UtcNow;

                entityInfo.OriginalValuesMap["UpdateDate"] = null;
                entityInfo.OriginalValuesMap["UpdatedBy"] = null;
            }
            return true;
        }

        public Dictionary<Type, List<EntityInfo>> BeforeSaveEntities(Dictionary<Type, List<EntityInfo>> saveMap)
        {
            _authRuleManager.Validate(_userSession.OperationToExecute, _userSession.ResourceIdOverApplingOperation,
                saveMap);
            return _breezeSaveManager.Execute(_userSession.OperationToExecute, _userSession.ResourceIdOverApplingOperation, saveMap);
        }
    }
}
