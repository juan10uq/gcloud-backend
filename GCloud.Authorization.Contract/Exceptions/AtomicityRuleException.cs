using System;

namespace GCloud.Authorization.Contract.Exceptions
{
    public class AtomicityRuleException : Exception
    {
        public AtomicityRuleException()
        {

        }

        public AtomicityRuleException(string message)
            : base(message)
        {

        }
    }
}
