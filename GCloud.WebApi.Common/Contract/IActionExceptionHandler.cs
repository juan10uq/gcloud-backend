using System.Web.Http.Filters;

namespace GCloud.WebApi.Common.Contract
{
    public interface IActionExceptionHandler
    {
        void HandleException(HttpActionExecutedContext filterContext);
    }
}
