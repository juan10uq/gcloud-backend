using GCloud.Authorization.Contract;
using GCloud.DataAccess.Contract;

namespace GCloud.DataAccess.EF
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        private readonly IAppSettings _appSettings;

        public ConnectionStringProvider(IAppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public string GetConnectionString()
        {
            //return string.Format(_appSettings.ReadString("DynamicConnectionString"), _userSession.TenantId);
            return _appSettings.ReadString("DynamicConnectionString");
        }
    }
}
