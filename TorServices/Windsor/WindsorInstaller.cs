using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Web.Http.Controllers;
using BusinessServices.Interfaces;
using BusinessServices.Implementation;
using DAL.UnitOfWork;

namespace TorServices.Windsor
{
    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                .BasedOn<IHttpController>()
                .LifestylePerWebRequest());
            container.Register(Component.For<UnitOfWork>().LifestyleTransient());
            container.Register(Component.For<ITokenServices>().ImplementedBy<TokenServices>()
                .LifestylePerWebRequest());
            container.Register(Component.For<IUserServices>().ImplementedBy<UserServices>()
                .LifestylePerWebRequest());
            container.Register(Component.For<ISearchServices>().ImplementedBy<SearchServices>()
                .LifestylePerWebRequest());
            //container.Register(Component.For<IConnection>().ImplementedBy<Connection>()
            //    .DependsOn(Dependency.OnValue("connectioString", ConfigurationManager.ConnectionStrings["TorDBConnection"].ConnectionString))
            //    );

        }
    }
}