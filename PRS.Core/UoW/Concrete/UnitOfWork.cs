using PRS.Core.UoW.Abstract;
using System;
using System.Data;

namespace PRS.Core.UoW.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IDbTransaction transaction)
        {
            State = IUnitOfWorkState.Open;
            Transaction = transaction;
        }

        public IUnitOfWorkState State { get; private set; }

        public IDbTransaction Transaction { get; private set; }

        public void Commit()
        {
            try
            {
                Transaction.Commit();
                State = IUnitOfWorkState.Committed;
            }
            catch (Exception)
            {
                Transaction.Rollback();
                throw;
            }
        }

        public void Rollback()
        {
            Transaction.Rollback();
            State = IUnitOfWorkState.Rolledback;
        }
    }
}