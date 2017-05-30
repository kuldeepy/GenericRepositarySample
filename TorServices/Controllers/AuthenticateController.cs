using BusinessServices.Interfaces;
using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using TorServices.Filters;

namespace TorServices.Controllers
{
    [ApiAuthenticationFilter]
    [RoutePrefix("api/tor-service")]
    public class AuthenticateController : ApiController
    {
        #region Private variable 
        private readonly ITokenServices _tokenServices;

        #endregion

        #region Public Constructor
        public AuthenticateController(ITokenServices tokensServices)
        {
            if (tokensServices == null)
                throw new ArgumentNullException("tokensServices");
            _tokenServices = tokensServices;
        }
        #endregion

        [HttpPost]
        [Route("login")]
        [Route("authenticate")]
        [Route("get/token")]
        public HttpResponseMessage Authenticate()
        {
            if (Thread.CurrentPrincipal != null && Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                var basiAuthenticationIdentity = Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
                if (basiAuthenticationIdentity != null)
                {
                    var userId = basiAuthenticationIdentity.UserId;
                    var token = _tokenServices.GenerateToken(userId);
                    //System.Web.HttpContext.Current.SetSessionStateBehavior(System.Web.SessionState.SessionStateBehavior.)
                    var response = Request.CreateResponse(HttpStatusCode.OK, "Authorized");
                    response.Headers.Add("Token", token.AuthToken);
                    response.Headers.Add("TokenExpiry", ConfigurationManager.AppSettings["AuthTokenExpiry"]);
                    response.Headers.Add("Access-Control-Expose-Headers", "Token,TokenExpiry");
                    return response;
                }
            }
            return null;
        }
    }
}
