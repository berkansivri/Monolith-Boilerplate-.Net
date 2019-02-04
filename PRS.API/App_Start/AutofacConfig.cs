using Autofac;
using Autofac.Integration.WebApi;
using PRS.Core.IoC.Autofac;
using System.Reflection;
using System.Web.Http;
using IContainer = Autofac.IContainer;

namespace PRS.API.App_Start
{
    public class AutofacConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterModule(new AutofacModules());
            Container = builder.Build();

            return Container;
        }
    }
}