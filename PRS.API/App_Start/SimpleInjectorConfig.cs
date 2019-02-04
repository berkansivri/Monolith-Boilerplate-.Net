using PRS.Core.IoC.SimpleInjector;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Reflection;
using System.Web.Http;

namespace PRS.API.App_Start
{
    public class SimpleInjectorConfig
    {
        public static Container Container = new Container();

        public static void Initialize(HttpConfiguration config)
        {
            Container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            Initialize(config, RegisterServices(config, Container));
        }

        public static void Initialize(HttpConfiguration config, Container container)
        {
            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static Container RegisterServices(HttpConfiguration config, Container container)
        {
            container.RegisterWebApiControllers(config, Assembly.GetExecutingAssembly());

            SimpleInjectorModules.RegisterServices(container);
            container.Verify();

            return container;
        }
    }
}