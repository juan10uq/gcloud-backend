using System.Configuration;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Owin;

[assembly: OwinStartup(typeof(GCloud.WebApi.Startup))]

namespace GCloud.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configure Web API for self-host. 
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            var issuer = "https://" + ConfigurationManager.AppSettings["auth0:Domain"] + "/";
            var audience = ConfigurationManager.AppSettings["auth0:ClientId"];
            var secret = TextEncodings.Base64.Encode(TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["auth0:ClientSecret"]));

            // Api controllers with an [Authorize] attribute will be validated with JWT
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    AllowedAudiences = new[] { audience },
                    IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                        {
                            new SymmetricKeyIssuerSecurityTokenProvider(issuer, secret)
                        }
                });
            // serve the api
            app.UseWebApi(config);
        }
    }
}
