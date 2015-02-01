using System;
using System.Linq;
using System.Security.Cryptography;
using Breeze.ContextProvider;
using Breeze.ContextProvider.EF6;
using GCloud.Authorization.Contract;
using GCloud.DataAccess.Contract;
using GCloud.Models;
using Newtonsoft.Json.Linq;

namespace GCloud.DataAccess.EF
{
    public class GCloudRepository : IGCloudRepository
    {

        private readonly EFContextProvider<GCloudContext> _contextProvider = new EFContextProvider<GCloudContext>();
        private readonly IUserSession _userContext;
        private GCloudContext Context { get { return _contextProvider.Context; } }

        public string Metadata
        {
            get
            {
                var metaContextProvider = new EFContextProvider<GCloudMetadataContext>();
                return metaContextProvider.Metadata();
            }
        }

        public GCloudRepository(IUserSession userContext)
        {
            _userContext = userContext;
        }

        public IQueryable<Country> Countries
        {
            get { return Context.Countries; }
        }

        public IQueryable<Customer> Customers
        {
            get { return  Context.Customers.Where(cust => cust.TenantId == _userContext.TenantId); }
        }

        public SaveResult SaveChanges(JObject saveBundle)
        {
            return _contextProvider.SaveChanges(saveBundle);
        }
    }
}
