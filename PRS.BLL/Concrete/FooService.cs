using PRS.BLL.Abstract;
using PRS.BLL.Result;
using PRS.Core.Aspects.Exception;
using PRS.Core.Aspects.Logging;
using PRS.Core.Caching;
using PRS.Core.UoW.Abstract;
using PRS.DAL.Abstract;
using PRS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PRS.BLL.Concrete
{
    public class FooService : ServiceBase<Foo>, IFooService
    {
        private IFooDAL _fooDAL;

        public FooService(IDbContext dbContext, IFooDAL FooDAL) : base(dbContext, FooDAL)
        {
            _fooDAL = FooDAL;
        }

        [LogAspect, ExceptionAspect]
        public BusinessResult CustomQuery()
        {
            BusinessResult result = new BusinessResult();
            List<Foo> fooList = InMemoryCache.GetOrSet("cachetest", () => _fooDAL.CustomQuery()).ToList();
            if(fooList != null)
            {
                result.Code = 1; result.Data = fooList; result.Type = "success";
            }
            else
            {
                result.Code = 2; result.Type = "warning"; result.Message = "Veri bulunamadı";
            }
            return result;
        }
    }
}