using System.Linq;
using Breeze.ContextProvider;
using GCloud.Models;
using Newtonsoft.Json.Linq;

namespace GCloud.DataAccess.Contract
{
    public interface IGCloudRepository
    {
        IQueryable<Country> Countries { get; }
        IQueryable<Customer> Customers { get; }
        string Metadata { get; }
        SaveResult SaveChanges(JObject saveBundle);
    }
}
