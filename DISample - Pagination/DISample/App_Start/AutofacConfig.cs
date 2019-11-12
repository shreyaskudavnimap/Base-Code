using Autofac;
using Autofac.Integration.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DISample.App_Start
{
    public class AutofacConfig
    {
        public static void Initialize()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(WebApiApplication).Assembly);

            builder.RegisterType<CategoryServices>()
                   .As<ICategoryServices>()
                   .InstancePerRequest();

            builder.RegisterType<ProductServices>()
                   .As<IProductServices>()
                   .InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}