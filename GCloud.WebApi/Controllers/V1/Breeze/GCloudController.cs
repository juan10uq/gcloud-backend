using System.Linq;
using System.Web.Http;
using Breeze.ContextProvider;
using Breeze.WebApi2;
using GCloud.DataAccess.Contract;
using GCloud.Models;
using GCloud.WebApi.Common.Filters;
using Newtonsoft.Json.Linq;

namespace GCloud.WebApi.BreezeControllers
{
    [BreezeExceptionFilter]
    [BreezeController]
    //[Authorize]
    public class GCloudController : ApiController
    {
        /// <summary>
        /// DB context
        /// </summary>
        private readonly IGCloudRepository _repository;

        public GCloudController(IGCloudRepository dal)
        {
            _repository = dal;
        }

        // ~/breeze/GCloud/Metadata 
        [HttpGet]
        public string Metadata()
        {
            return _repository.Metadata;
        }

        // ~/breeze/GCloud/Customers
        [HttpGet]
        public IQueryable<Customer> Customers()
        {
            return _repository.Customers;
        }

        // ~/breeze/GCloud/Countries
        [HttpGet]
        public IQueryable<Country> Countries()
        {
            return _repository.Countries;
        }

        /// <summary>
        /// Query returing a 1-element array with a lookups object whose 
        /// properties are all Countries.
        /// </summary>
        /// <returns>
        /// Returns one object, not an IQueryable, 
        /// whose properties are "countries".
        /// The items arrive as arrays.
        /// </returns>
        [HttpGet]
        public object Lookups()
        {
            var countries = _repository.Countries;
            return new { countries };
        }


        // ~/breeze/GCloud/CreateCustomer
        [HttpPost]
        public SaveResult CreateCustomer(JObject saveBundle)
        {
            return _repository.SaveChanges(saveBundle);
        }

        // ~/breeze/GCloud/EditCustomer
        [HttpPost]
        public SaveResult EditCustomer(JObject saveBundle)
        {
            return _repository.SaveChanges(saveBundle);
        }

        // ~/breeze/GCloud/DeleteCustomer
        [HttpPost]
        public SaveResult DeleteCustomer(JObject saveBundle)
        {
            return _repository.SaveChanges(saveBundle);
        }
    }
}
