using System.Data;

namespace PRS.Core.UoW.Abstract
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateOpenConnection();
    }
}