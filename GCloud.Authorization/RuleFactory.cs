using System;
using System.Collections.Generic;
using System.Reflection;
using GCloud.Authorization.Contract;
using GCloud.Authorization.Rules;
using GCloud.DataAccess.Contract;

namespace GCloud.Authorization
{

    public class RuleFactory : IRuleFactory
    {
        private readonly IUserSession _userContext;
        private IGCloudUnitOfWork _readContext;
        private readonly List<IRuleActivity> _activityRules ;
        public RuleFactory(IUserSession userContext, IGCloudUnitOfWork context)
        {
            _readContext = context;
            _userContext = userContext;
            _activityRules = new List<IRuleActivity>
            {
                new CustomerTenantRule(userContext, _readContext),
                new CustomerAtomicityRule()
            };
        }

        public List<IRuleActivity> Rules
        {
            get { return _activityRules; }
        }

        /// <summary>
        /// Scan all specified assemblies after AppIdentiy.
        /// </summary>
        public List<IRuleActivity> ScanForRules(params Assembly[] assemblies)
        {
            var activityRules = new List<IRuleActivity>();

            var appType = typeof(IRuleActivity);
            foreach (var assembly in assemblies)
            {
                foreach (var type in assembly.GetTypes())
                {
                    if (!appType.IsAssignableFrom(type) || type.IsAbstract || type.IsInterface)
                        continue;
                    activityRules.Add((IRuleActivity)Activator.CreateInstance(type, new object[] { _userContext, _readContext }));
                }
            }
            return activityRules;
        }
    }
}
