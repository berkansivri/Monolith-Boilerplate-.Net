using System.Data;

namespace PRS.Core.UoW.Abstract
{
    public enum IUnitOfWorkState
    {
        Open, Committed, Rolledback
    }

    public interface IUnitOfWork
    {
        IUnitOfWorkState State { get; }
        IDbTransaction Transaction { get; }

        void Commit();

        void Rollback();
    }
}