using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Ninject;
using ProductStore.Domain.Interfaces;
using ProductStore.Domain.Repositories;

namespace lab4_MVC.Util
{
    public class StoreModule : IDependencyResolver
    {
        private IKernel kernel;

        public StoreModule(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IProductRepository>().To<ProductRepository>();
            
        }
    }
}