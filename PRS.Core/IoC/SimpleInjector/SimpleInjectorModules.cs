using Oracle.ManagedDataAccess.Client;
using PRS.Core.Caching;
using PRS.Core.UoW.Abstract;
using PRS.Core.UoW.Concrete;
using SimpleInjector;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace PRS.Core.IoC.SimpleInjector
{
    public static class SimpleInjectorModules
    {
        public static void RegisterServices(Container container)
        {
            var ServiceRegistrations =
                            from type in Assembly.Load("PRS.BLL").GetTypes()
                            where (type.Name.EndsWith("Service") || type.Name.EndsWith("Base")) && type.IsClass
                            from service in type.GetInterfaces()
                            select new { service, type };

            foreach (var reg in ServiceRegistrations)
            {
                container.Register(reg.service, reg.type, Lifestyle.Scoped);
            }

            var DALRegistrations =
                            from type in Assembly.Load("PRS.DAL").GetTypes()
                            where type.Name.EndsWith("DAL") && type.IsClass
                            from service in type.GetInterfaces()
                            select new { service, type };

            foreach (var reg in DALRegistrations)
            {
                container.Register(reg.service, reg.type, Lifestyle.Scoped);
            }

            container.Register<IDbContext, DbContext>(Lifestyle.Scoped);

            container.Register<IDbConnectionFactory>(() =>
            {
                var stringBuilder = new OracleConnectionStringBuilder(ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString);
                return new DbConnectionFactory(() =>
                {
                    var conn = new OracleConnection(stringBuilder.ConnectionString);
                    conn.Open();
                    return conn;
                });
            }, Lifestyle.Scoped);
        }
    }
}