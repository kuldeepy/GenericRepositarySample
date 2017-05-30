using BusinessServices.Interfaces;
using System.Threading;
using System.Web.Http.Controllers;

namespace TorServices.Filters
{
    /// <summary>
    /// Custom Authentication Filter Extending basic Authentication
    /// </summary>
    public class ApiAuthenticationFilter : GenericAuthenticationFilter
    {
        /// <summary>
        /// Default Authentication Constructor
        /// </summary>
        public ApiAuthenticationFilter()
        {
        }

        /// <summary>
        /// AuthenticationFilter constructor with isActive parameter
        /// </summary>
        /// <param name="isActive"></param>
        public ApiAuthenticationFilter(bool isActive)
            : base(isActive)
        {
        }

        protected override bool OnAuthorizeUser(string user, string pass, HttpActionContext filterContext)
        {
            var provider = filterContext.ControllerContext.Configuration
                .DependencyResolver.GetService(typeof(IUserServices)) as IUserServices;
            if (provider != null)
            {
                var userId = provider.Authenticate(user, pass);
                if (userId > 0)
                {
                    var basicAuthenticationIdentity = Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
                    if (basicAuthenticationIdentity != null)
                        basicAuthenticationIdentity.UserId = userId;
                    return true;
                }
            }
            return false;
        }
    }
}