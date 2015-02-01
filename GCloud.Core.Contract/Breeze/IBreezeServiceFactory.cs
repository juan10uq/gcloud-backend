using System;
using GCloud.Models;

namespace GCloud.Core.Contract.Breeze
{
    public interface IBreezeServiceFactory
    {
        IBreezeSaveService Get(Guid resourceId, string operation);
    }
}
