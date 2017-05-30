using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using TorServices.Windsor;

namespace TorServices
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            ConfigureWindsorConfig();
        }

        /// <summary>
        /// Configures the windsor configuration.
        /// </summary> 
        private void ConfigureWindsorConfig()
        {
            IWindsorContainer container = new WindsorContainer().Install(new WindsorInstaller());
            var dependencyResolver = new WindsorDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = dependencyResolver;
        }
    }
}
