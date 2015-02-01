using Breeze.ContextProvider.EF6;
using GCloud.DataAccess.Contract;

namespace GCloud.DataAccess.EF
{
    public class GCloudContextProvider : EFContextProvider<GCloudContext>
    {
        public GCloudContextProvider(IConnectionStringProvider connStringProvider)
        {
            Context.Database.Connection.ConnectionString = connStringProvider.GetConnectionString();
        }
    }
}
