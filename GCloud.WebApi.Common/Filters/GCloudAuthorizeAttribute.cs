using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using GCloud.Authorization.Contract;
using GCloud.Models;

namespace GCloud.WebApi.Common.Filters
{
    [AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Method, Inherited = true,
       AllowMultiple = true)]
    public class GCloudAuthorizeAttribute : System.Web.Http.AuthorizeAttribute
    {

        private Guid _resourceId;
        private Operations _operation;
      
        private IResourceService ResourceService { get; set; }
       
        private IUserSession UserContext { get; set; }

        public GCloudAuthorizeAttribute(Guid resourceId, Operations operation)
        {
            _resourceId = resourceId;
            _operation = operation;
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (!ResourceService.Authorize(UserContext.UserName, _resourceId, _operation))
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
        }
    }
}
