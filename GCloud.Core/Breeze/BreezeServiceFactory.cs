using System;
using GCloud.Authorization.Contract;
using GCloud.Core.Breeze.Services;
using GCloud.Core.Contract.Breeze;
using GCloud.DataAccess.Contract;

namespace GCloud.Core.Breeze
{
    public class BreezeServiceFactory : IBreezeServiceFactory
    {
        private readonly IUserSession _userSession;
        private readonly IGCloudUnitOfWork _readInventoryContext;

        public BreezeServiceFactory(IUserSession userSession, IGCloudUnitOfWork readContext)
        {
            _userSession = userSession;
            _readInventoryContext = readContext;
        }


        public IBreezeSaveService Get(Guid resourceId, string operation)
        {
            IBreezeSaveService service = null;

            if (AppResources.None == resourceId)
                return null;
            if (AppResources.Customer == resourceId)
                if (operation.Equals(Operations.Create))
                {
                    service = new CreateCustomer(_userSession, _readInventoryContext);
                }
            return service;
        }
    }
}
