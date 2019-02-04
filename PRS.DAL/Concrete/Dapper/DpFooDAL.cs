using Dapper;
using PRS.Core.UoW.Abstract;
using PRS.DAL.Abstract;
using PRS.Entities.Concrete;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace PRS.DAL.Concrete.Dapper
{
    public class DpFooDAL : DpEntityRepositoryBase<Foo>, IFooDAL
    {
        public DpFooDAL(IDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Foo> CustomQuery()
        {
            var x = Db.Query<Foo>("select * from DENEME2", transaction: Transaction).ToList();
            dbContext.Commit();
            return x;
        }
    }
}