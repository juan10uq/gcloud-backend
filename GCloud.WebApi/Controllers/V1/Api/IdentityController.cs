using System.Collections.Generic;
using System.Web.Http;
using GCloud.Authorization.Contract;

namespace GCloud.WebApi.Controllers
{
    public class IdentityController : ApiController
    {
        private readonly IResourceService _resourceService;
        private readonly IUserSession _userSession;

        public IdentityController(IResourceService resourceService, IUserSession userSession)
        {
            _resourceService = resourceService;
            _userSession = userSession;
        }

        [Route("api/identity/operations")]
        public List<string> GetOperations()
        {
            return _resourceService.GetOperationsByUserName(_userSession.UserName);
        }
    }
}
