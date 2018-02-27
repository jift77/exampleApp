using ExampleApp.Models;
using Ninject;
using Ninject.Extensions.ChildKernel;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using System.Web.Http.Dependencies;

namespace ExampleApp.Infraestructure
{
    public class NinjectResolver : IDependencyResolver, System.Web.Mvc.IDependencyResolver
    {
        private IKernel kernel;

        public NinjectResolver() : this (new StandardKernel()) { }

        public NinjectResolver(IKernel ninjectKernel) {
            kernel = ninjectKernel;
            AddBindings(kernel);
        }

        public IDependencyScope BeginScope() => this;

        public void Dispose()
        {
            
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings(IKernel kernel) {
            kernel.Bind<IRepository>().To<Repository>().InSingletonScope();
            kernel.Bind<IContentNegotiator>().To<CustomNegotiator>();
        }
    }
}