using PRS.Entities.Concrete;
using System.Collections.Generic;

namespace PRS.DAL.Abstract
{
    public interface IFooDAL : IEntityRepository<Foo>
    {
        IEnumerable<Foo> CustomQuery();
    }
}