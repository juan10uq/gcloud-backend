using System;
using System.Collections.Generic;
using Breeze.ContextProvider;
using GCloud.Authorization.Contract;
using GCloud.Authorization.Contract.Exceptions;
using GCloud.DataAccess.Contract;
using GCloud.Models;

namespace GCloud.Authorization.Rules
{
    public class CustomerAtomicityRule : IRuleActivity
    {
        public bool Validate(Dictionary<Type, List<EntityInfo>> saveMap)
        {
            var errors = new List<EntityError>();
            if (saveMap.Count == 1)
            {
                var customers = saveMap[typeof(Customer)];
                var phones = saveMap[typeof(PhoneNumber)];
                var addresess = saveMap[typeof(Address)];

                // We are expecting to recieve ONE Customer
                if ((customers != null && customers.Count == 1))
                {
                    if ((phones == null || (phones.Count >= 0 && phones.Count <= 10)) && (addresess == null || (addresess.Count >= 0 && addresess.Count <= 10)))
                        return true;
                }
            }
            errors.Add(new EntityError { ErrorMessage = "This customer activity requires more entities to be performed", ErrorName = "AtomicityRule", EntityTypeName = "Customer" });
            throw new EntityErrorsException(errors);
        }

        public bool IsMatch(Guid resourceId, string operation)
        {
            return (AppResources.Customer == resourceId && ((operation == Operations.Create) || (operation == Operations.Update)));
        }
    }
}
