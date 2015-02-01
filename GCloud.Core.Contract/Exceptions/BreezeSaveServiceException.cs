using System;

namespace GCloud.Core.Contract.Exceptions
{
    public class BreezeSaveServiceException : Exception
    {
        public BreezeSaveServiceException()
        {

        }

        public BreezeSaveServiceException(string message)
            : base(message)
        {

        }
    }
}
