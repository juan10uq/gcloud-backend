using System;
using System.Collections.Generic;
using System.Linq;
using Breeze.ContextProvider;
using GCloud.Authorization.Contract;
using GCloud.Models;

namespace GCloud.Authorization.Rules
{
    public class CustomerGateWayRule : IRuleActivity
    {

        public bool Validate(Dictionary<Type, List<EntityInfo>> saveMap)
        {
            var errors = new List<EntityError>();
                if (saveMap.Any(entityTypeInfo => entityTypeInfo.Key != typeof(Customer) && entityTypeInfo.Key != typeof(Address) && entityTypeInfo.Key != typeof(PhoneNumber)))
                {
                    errors.Add(new EntityError { ErrorMessage = "You are trying to do another activity that is not allowed on customer activity", ErrorName = "GateWayRule", EntityTypeName = "Customer" });
                    throw new EntityErrorsException(errors);
                }
                return true;
        }

        public bool IsMatch(Guid resourceId, string operation)
        {
            return (AppResources.Customer == resourceId && ((operation == Operations.Update) || (operation == Operations.Create) || (operation == Operations.Delete)));
        }
    }
}
