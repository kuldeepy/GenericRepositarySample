using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;

namespace TorServices.Windsor
{
    /// <summary>
    /// This class is used to reslove dependency from the windsor conatiner.
    /// </summary>
    public class WindsorDependencyResolver : IDependencyResolver
    {
        private readonly IWindsorContainer _container;
        private readonly IDisposable _scope;

        /// <summary>
        /// this constructor intiliaze WindsorDependencyResolver instance
        /// </summary>
        /// <param name="container"></param>
        public WindsorDependencyResolver(IWindsorContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            _container = container;
        }

        /// <summary>
        /// this method begin the scope of the resolved instance.
        /// </summary>
        /// <returns></returns>
        public IDependencyScope BeginScope()
        {
            return new WindsorDependencyScope(_container);
        }

        /// <summary>
        /// this method is used to freeing the unmanged resources.
        /// </summary>
        public void Dispose()
        {
            _container.Dispose();
        }

        /// <summary>
        /// this method is used resolve the specify type.
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns>instance of service type</returns>
        public object GetService(Type serviceType)
        {
            return _container.Kernel.HasComponent(serviceType) ? _container.Resolve(serviceType) : null;
        }

        /// <summary>
        /// this method is used to resolve the array of onjects.
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.ResolveAll(serviceType).Cast<object>().ToArray();
        }
    }
}