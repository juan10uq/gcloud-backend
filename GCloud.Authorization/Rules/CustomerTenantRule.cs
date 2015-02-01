using System;
using System.Collections.Generic;
using System.Linq;
using Breeze.ContextProvider;
using GCloud.Authorization.Contract;
using GCloud.DataAccess.Contract;
using GCloud.Models;

namespace GCloud.Authorization.Rules
{
    public class CustomerTenantRule : IRuleActivity
    {
        private readonly IUserSession _userSession;
        private readonly IGCloudUnitOfWork _context;

        public CustomerTenantRule(IUserSession userContext, IGCloudUnitOfWork context)
        {
            _userSession = userContext;
            _context = context;
        }

        public bool Validate(Dictionary<Type, List<EntityInfo>> saveMap)
        {
            try
            {
                var customers = saveMap[typeof(Customer)];
                var errors = new List<EntityError>();

                    var customer = customers.FirstOrDefault();
                    if (customer != null && (customer.EntityState == EntityState.Modified || customer.EntityState == EntityState.Deleted))
                    {
                        var customer1 = customer.Entity as Customer;

                        if (customer1 != null)
                        {
                            var customerEntity = _context.CustomerRepository.Get(customer1.Id) ;
                            if (customerEntity != null)
                            {
                                if (customerEntity.TenantId != _userSession.TenantId)
                                {
                                    errors.Add(new EntityError { ErrorMessage = "This customer does not belong to this user tenant context", ErrorName = "TenantRule", EntityTypeName = "Customer"});
                                }

                            }
                        }
                    }

                var addresses = saveMap[typeof (Address)];

                if ((from addressMap in addresses where (addressMap.EntityState == EntityState.Modified || addressMap.EntityState == EntityState.Deleted) select addressMap.Entity).OfType<Address>().Select(addresesEntity => _context.AddressRepository.Get(addresesEntity.Id)).Where(addresData => addresData != null).Any(addresData => addresData.TenantId != _userSession.TenantId))
                {
                    errors.Add(new EntityError { ErrorMessage = "This address does not belong to this user tenant context", ErrorName = "TenantRule", EntityTypeName = "Address" });
                }

                var phones = saveMap[typeof(PhoneNumber)];

                if ((from phoneMap in phones where (phoneMap.EntityState == EntityState.Modified || phoneMap.EntityState == EntityState.Deleted) select phoneMap.Entity).OfType<PhoneNumber>().Select(phoneEntity => _context.PhoneNumberRepository.Get(phoneEntity.Id)).Where(phoneData => phoneData != null).Any(phoneData => phoneData.TenantId != _userSession.TenantId))
                {
                    errors.Add(new EntityError { ErrorMessage = "This phone does not belong to this user tenant context", ErrorName = "TenantRule", EntityTypeName = "Phone" });
                }

                if(errors.Count > 0)
                    throw new EntityErrorsException(errors);

                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool IsMatch(Guid resourceId, string operation)
        {
            return (AppResources.Customer == resourceId && ((operation == Operations.Update) || (operation == Operations.Delete)));
        }
    }
}
