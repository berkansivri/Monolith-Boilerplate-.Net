using PRS.Core.UoW.Abstract;
using PRS.DAL.Abstract;
using PRS.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Data;

namespace PRS.DAL.Concrete
{
    public abstract class RepositoryBase<T> : IEntityRepository<T> where T : class, IEntity, new()
    {
        protected readonly IDbContext dbContext;

        public RepositoryBase(IDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IDbConnection Db =>
          dbContext.UnitOfWork.Transaction.Connection;

        public IDbTransaction Transaction =>
          dbContext.UnitOfWork.Transaction;

        public abstract long Add(T entity);

        public abstract long AddList(IEnumerable<T> EntityList);

        public abstract bool Update(T entity);

        public abstract bool UpdateList(IEnumerable<T> EntityList);

        public abstract bool Delete(T entity);

        public abstract bool DeleteList(IEnumerable<T> EntityList);

        [Obsolete("This method will delete all record in table")]
        public abstract bool DeleteAll();

        public abstract T Get(int Id);

        public abstract IEnumerable<T> GetAll();
    }
}