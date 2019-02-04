using PRS.API.App_Start;
using System.Web.Http;

namespace PRS.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            log4net.Config.XmlConfigurator.Configure();
            //AutofacConfig.Initialize(GlobalConfiguration.Configuration);
            SimpleInjectorConfig.Initialize(GlobalConfiguration.Configuration);
        }
    }
}