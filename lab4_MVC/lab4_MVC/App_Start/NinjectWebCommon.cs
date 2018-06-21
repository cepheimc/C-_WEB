using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Ninject.Web.Common;

namespace lab4_MVC.App_Start
{
    public static class NinjectWebCommon
    {
        private static void RegisterServices(IKernel kernel)
        {
            System.Web.Mvc.DependencyResolver.SetResolver(new
                lab4_MVC.Util.StoreModule(kernel));
        }
    }
}