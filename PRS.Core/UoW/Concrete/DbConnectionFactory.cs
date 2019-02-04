using PRS.Core.UoW.Abstract;
using System;
using System.Data;

namespace PRS.Core.UoW.Concrete
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly Func<IDbConnection> connectionFactoryFn;

        public DbConnectionFactory(Func<IDbConnection> connectionFactory)
        {
            connectionFactoryFn = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        }

        public IDbConnection CreateOpenConnection()
        {
            return connectionFactoryFn();
        }
    }
}