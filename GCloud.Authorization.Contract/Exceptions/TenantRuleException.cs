using System;

namespace GCloud.Authorization.Contract.Exceptions
{
    public class TenantRuleException : Exception
    {
        public TenantRuleException()
        {

        }

        public TenantRuleException(string message)
            : base(message)
        {

        }
    }
}
