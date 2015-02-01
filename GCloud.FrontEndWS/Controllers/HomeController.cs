using System.Collections.Generic;
using System.IdentityModel.Services;
using System.Security.Claims;
using System.Web.Mvc;
using GCloud.FrontEndWS.Models;

namespace GCloud.FrontEndWS.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var email = ClaimsPrincipal.Current.FindFirst(ClaimTypes.Name).Value;
            var accessToken = ClaimsPrincipal.Current.FindFirst("access_token").Value;
            var user = new User { UserName = User.Identity.Name, AccessToken = accessToken, Activities = new List<string>(){"customer_create"} };
            return View(user);
        }


        public void LogOff()
        {
           // var returnUrl = ConfigurationManager.AppSettings["returnUrl"];

            FederatedAuthentication.SessionAuthenticationModule.SignOut();
            Response.Redirect("http://localhost/GCloud.MarketSite/");
        }
    }
}