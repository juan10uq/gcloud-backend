using Breeze.ContextProvider;
using Newtonsoft.Json.Linq;

namespace GCloud.DataAccess.Contract
{
    public interface IBreeze
    {
        string Metadata { get; }

        SaveResult SaveChanges(JObject saveBundle);
    }
}
