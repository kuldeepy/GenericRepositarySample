using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;

namespace TorServices.Windsor
{
    /// <summary>
    /// This class is used for the dependency resolver scope defination.
    /// </summary>
    public class WindsorDependencyScope : IDependencyScope
    {
        private readonly IWindsorContainer _container;
        private readonly IDisposable _scope;

        /// <summary>
        /// This constructor is used to intiliaze the Idependency scope instance.
        /// </summary>
        /// <param name="container"></param>
        public WindsorDependencyScope(IWindsorContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            _container = container;
            _scope = container.BeginScope();
        }

        /// <summary>
        /// this method dispose the scope of dependency.
        /// </summary>
        public void Dispose()
        {
            _scope.Dispose();
        }

        /// <summary>
        /// this serive method reslove the dependency.
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns>service instance</returns>
        public object GetService(Type serviceType)


        {
            return _container.Kernel.HasComponent(serviceType) ? _container.Resolve(serviceType) : null;
        }

        /// <summary>
        /// this method resolve list of dependency.
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns>list of reslove instance</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.ResolveAll(serviceType).Cast<object>().ToArray();
        }
    }
}