using PRS.BLL.Abstract;
using PRS.BLL.Result;
using PRS.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PRS.API.Controllers
{
    public class BaseController<T> : ApiController where T : class, IEntity, new()
    {
        private IServiceBase<T> _serviceBase;

        public BaseController(IServiceBase<T> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = _serviceBase.GetAll();
            return GetResult(result);
        }

        [HttpGet]
        public IHttpActionResult Get(int Id)
        {
            var result = _serviceBase.Get(Id);
            return GetResult(result);
        }

        [HttpPost]
        public IHttpActionResult Add(T obj)
        {
            var result = _serviceBase.Add(obj);
            return GetResult(result);
        }

        [HttpPost]
        public IHttpActionResult AddList(List<T> objList)
        {
            var result = _serviceBase.AddList(objList);
            return GetResult(result);
        }

        [HttpPost]
        public IHttpActionResult Update(T obj)
        {
            var result = _serviceBase.Update(obj);
            return GetResult(result);
        }

        [HttpPost]
        public IHttpActionResult UpdateList(List<T> objList)
        {
            var result = _serviceBase.UpdateList(objList);
            return GetResult(result);
        }

        [HttpPost]
        public IHttpActionResult Delete(T obj)
        {
            var result = _serviceBase.Delete(obj);
            return GetResult(result);
        }

        [HttpPost]
        public IHttpActionResult DeleteList(List<T> objList)
        {
            var result = _serviceBase.DeleteList(objList);
            return GetResult(result);
        }

        [HttpGet]
        public IHttpActionResult DeleteAll()
        {
            var result = _serviceBase.DeleteAll();
            return GetResult(result);
        }

        public IHttpActionResult GetResult(BusinessResult result)
        {
            switch (result.Code)
            {
                case 1: return Ok(result);
                case 2: return Content(HttpStatusCode.NotAcceptable, result);
                case 3: return Content(HttpStatusCode.BadRequest, result);
                case 4: return Content(HttpStatusCode.Conflict, result);
                case 5: return Unauthorized();
                case 6: return Content(HttpStatusCode.NotFound, result);
                default: return Ok(result);
            }
        }
    }
}
