using System.Web.Configuration;
using GCloud.DataAccess.Contract;
using GCloud.DataAccess.EF.Exceptions;

namespace GCloud.DataAccess.EF
{
    public class AppSettings : IAppSettings
    {
        /// <summary>
        /// Reads info [Application settings] from the config file.
        /// </summary>
        /// <param name="key">App setting key</param>
        /// <returns>value</returns>
        public string ReadString(string key)
        {
            string result;
            if (WebConfigurationManager.AppSettings[key] != null)
                result = WebConfigurationManager.AppSettings[key];
            else
                throw new ConfigurationManagerException(string.Format("The {0} key is not setup in the Configuration file.", key));
            return result;
        }
    }
}
