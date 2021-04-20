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
                RequiredScopes = new[] { "odbAppApi" },               
                BackchannelHttpHandler = new HttpClientHandler { ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator }
            });          
        }
    }
}
