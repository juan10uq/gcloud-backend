using System;
using System.Collections.Generic;
using System.Linq;
using Breeze.ContextProvider;
using GCloud.Authorization.Contract;
using GCloud.Authorization.Contract.Exceptions;
using GCloud.Models;

namespace GCloud.Authorization
{

    public class AuthRuleManager : IAuthRuleManager
    {
        private readonly List<IRuleActivity> _activityRules = new List<IRuleActivity>();

        public AuthRuleManager(IRuleFactory ruleFactory)
        {
            _activityRules = ruleFactory.Rules;
        }

        public bool Validate(string operation, Guid resourseId, Dictionary<Type, List<EntityInfo>> saveMap)
        {
            if (saveMap.Any(entityList => entityList.Value.Count(e => e.EntityState == EntityState.Deleted) > 0))
            {
                throw new AtomicityRuleException("You do not have permission to delete a record.");
            }

            return _activityRules.FindAll(r => r.IsMatch(resourseId, operation)).All(activityRule => activityRule.Validate(saveMap));
        }
    }
}
