﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FatihOzkirSolutions.Business.DependencyResolver.AutoMapper;
using FatihOzkirSolutions.Business.DependencyResolver.Ninject;
using FatihOzkirSolutions.Core.Utilities.Mvc.Infrastructure;

namespace FatihOzkirSolutions.MvcWebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new BusinessModule(),new AutoMapperModule()));
        }
    }
}
