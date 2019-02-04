using System.Data;

namespace PRS.Core.UoW.Abstract
{
    public enum IDbContextState
    {
        Closed,
        Open,
        Committed,
        RolledBack
    }

    public interface IDbContext
    {
        IDbContextState State { get; }
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        IUnitOfWork UnitOfWork { get; }

        void Commit();

        void Rollback();
    }
}