using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData;
using GCloud.DataAccess.EF;
using GCloud.Models;
using GCloud.WebApi.Common.Filters;

namespace GCloud.WebApi.OdataControllers
{
    [LoggingGCloudSession]
    [BreezeExceptionFilter]
    public class CustomersController : ODataController
    {
        private readonly GCloudUnitOfWork _context;

        public CustomersController(GCloudUnitOfWork context)
        {
            _context = context;
        }

        /// <summary>
        /// GET odata/Sites
        /// </summary>
        [EnableQuery]
        public IQueryable<Customer> GetCustomers()
        {
            return _context.CustomerRepository.All();
        }

        [EnableQuery]
        public SingleResult<Customer> Get([FromODataUri] Guid key)
        {
            IQueryable<Customer> result = _context.CustomerRepository.FilterBy(c => c.Id == key);
            return SingleResult.Create(result);
        }

        private bool CustomerExists(Guid id)
        {
            return _context.CustomerRepository.All().Count(site => site.Id == id) > 0;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }
    }
}
