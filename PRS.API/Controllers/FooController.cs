using PRS.BLL.Abstract;
using PRS.Entities.Concrete;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.OutputCache.V2;

namespace PRS.API.Controllers
{
    public class FooController : BaseController<Foo>
    {
        private IFooService _FooService;

        public FooController(IFooService FooService) : base(FooService)
        {
            _FooService = FooService;
        }
        [HttpGet]
        public IHttpActionResult Custom()
        {
            var result = _FooService.CustomQuery();
            return GetResult(result);
        }
    }
}