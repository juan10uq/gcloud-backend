using System;

namespace GCloud.DataAccess.EF.Exceptions
{
    public class ConfigurationManagerException : Exception
    {
        public ConfigurationManagerException()
        {
        }
        public ConfigurationManagerException(string message)
            : base(message)
        {
        }
    }
}
