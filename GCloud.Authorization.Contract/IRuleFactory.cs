using System.Collections.Generic;
using System.Reflection;

namespace GCloud.Authorization.Contract
{
    public interface IRuleFactory
    {
        List<IRuleActivity> ScanForRules(params Assembly[] assemblies);
        List<IRuleActivity> Rules { get; }
    }
}
