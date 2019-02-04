using Autofac;
using Oracle.ManagedDataAccess.Client;
using PRS.Core.UoW.Abstract;
using PRS.Core.UoW.Concrete;
using System.Configuration;
using System.Linq;
using System.Reflection;
using Module = Autofac.Module;

namespace PRS.Core.IoC.Autofac
{
    public class AutofacModules : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register<IDbConnectionFactory>(options =>
            {
                var stringBuilder = new OracleConnectionStringBuilder(ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString);
                return new DbConnectionFactory(() =>
                {
                    var conn = new OracleConnection(stringBuilder.ConnectionString);
                    conn.Open();
                    return conn;
                });
            }).InstancePerDependency();

            builder.RegisterType<DbContext>().As<IDbContext>().InstancePerRequest();

            builder.RegisterAssemblyTypes(Assembly.Load("PRS.DAL"))
                    .Where(x => x.Name.EndsWith("DAL"))
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(Assembly.Load("PRS.BLL"))
                    .Where(x => x.Name.EndsWith("Service"))
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();
        }
    }
}