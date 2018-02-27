using ExampleApp.Models;
using Ninject;
using Ninject.Extensions.ChildKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace ExampleApp.Infraestructure
{
    public class NinjectResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectResolver() : this (new StandardKernel()) { }

        public NinjectResolver(IKernel ninjectKernel, bool scope = false) {
            kernel = ninjectKernel;
            if (!scope)
                AddBindings(kernel);
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectResolver(AddRequestBindings(new ChildKernel(kernel)), true);
        }

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

        }

        private IKernel AddRequestBindings(IKernel kernel) {
            kernel.Bind<IRepository>().To<Repository>().InSingletonScope();
            return kernel;
        }
    }
}