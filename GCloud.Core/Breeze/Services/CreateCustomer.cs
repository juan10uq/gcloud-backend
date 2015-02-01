using System;
using System.Collections.Generic;
using Breeze.ContextProvider;
using GCloud.Authorization.Contract;
using GCloud.Core.Contract.Breeze;
using GCloud.DataAccess.Contract;

namespace GCloud.Core.Breeze.Services
{
    public class CreateCustomer : IBreezeSaveService
    {
        public IUserSession UserSession { private get; set; }
        private readonly IGCloudUnitOfWork _context;

        public CreateCustomer(IUserSession userSession, IGCloudUnitOfWork context)
        {
            UserSession = userSession;
            _context = context;
        }

        public Dictionary<Type, List<EntityInfo>> Execute(Dictionary<Type, List<EntityInfo>> saveMap)
        {
            return saveMap;
        }
    }
}
