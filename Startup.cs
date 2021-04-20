using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using NLog;
using NLog.Fluent;
using NLog.Owin.Logging;
using Owin;
using Serilog;
using System;
using System.IdentityModel.Tokens;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

[assembly: OwinStartup(typeof(gasDiesel.Startup))]

namespace gasDiesel
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            JwtSecurityTokenHandler.InboundClaimTypeMap.Clear();

            app.UseNLog((eventType) => LogLevel.Debug);

            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                ClientId = "odbApp",
                ClientSecret = "odbAppSecret",
                Authority = "https://localhost:44310",
                // ValidationMode = ValidationMode.ValidationEndpoint,
                // ValidationMode = ValidationMode.Local,
                // AuthenticationType = "Bearer",
                RequiredScopes = new[] { "odbAppApi" },
                // NameClaimType = System.Security.Claims.ClaimTypes.Name,
                // RoleClaimType = System.Security.Claims.ClaimTypes.Role,
                BackchannelHttpHandler = new HttpClientHandler { ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator }
            });

            // configure web api
            //  var config = new HttpConfiguration();
            // WebApiConfig.Register(config);
            // app.UseWebApi(config);
        }
    }
}
