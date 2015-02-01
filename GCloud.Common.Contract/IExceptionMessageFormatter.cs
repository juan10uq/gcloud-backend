using System;

namespace GCloud.Common.Contract
{
    public interface IExceptionMessageFormatter
    {
        string GetEntireExceptionStack(Exception ex);
    }
}
