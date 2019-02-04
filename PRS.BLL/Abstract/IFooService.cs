using PRS.BLL.Result;
using PRS.Entities.Concrete;
using System.Collections.Generic;

namespace PRS.BLL.Abstract
{
    public interface IFooService : IServiceBase<Foo>
    {
        BusinessResult CustomQuery();
    }
}