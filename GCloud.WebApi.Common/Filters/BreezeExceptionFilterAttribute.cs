using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using GCloud.Authorization.Contract.Exceptions;

namespace GCloud.WebApi.Common.Filters
{
    public class BreezeExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is AtomicityRuleException || context.Exception is TenantRuleException || context.Exception is GateWayRuleException)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.Forbidden)
                {
                    Content = new StringContent(context.Exception.Message),
                };

                context.Response = resp;
            }
            else if (context.Exception is UnauthorizedAccessException)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent(context.Exception.Message),
                };
                context.Response = resp;
            }
        }
    }
}
