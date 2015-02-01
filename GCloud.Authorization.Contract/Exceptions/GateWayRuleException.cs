using System;

namespace GCloud.Authorization.Contract.Exceptions
{
    public class GateWayRuleException : Exception
    {
        public GateWayRuleException()
        {

        }

        public GateWayRuleException(string message)
            : base(message)
        {

        }
    }
}
