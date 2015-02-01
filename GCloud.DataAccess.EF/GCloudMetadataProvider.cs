using Breeze.ContextProvider.EF6;
using GCloud.DataAccess.Contract;

namespace GCloud.DataAccess.EF
{
    public class GCloudMetadataProvider : EFContextProvider<GCloudMetadataContext>
    {
        public GCloudMetadataProvider(IConnectionStringProvider connStringProvider)
        {
            Context.Database.Connection.ConnectionString = connStringProvider.GetConnectionString();
        }
    }
}
