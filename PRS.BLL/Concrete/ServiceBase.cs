using PRS.BLL.Abstract;
using PRS.BLL.Result;
using PRS.Core.Aspects.Logging;
using PRS.Core.UoW.Abstract;
using PRS.DAL.Abstract;
using PRS.Entities.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PRS.BLL.Concrete
{
    public abstract class ServiceBase<T> : IServiceBase<T> where T : class, IEntity, new()
    {
        protected readonly IEntityRepository<T> _repositoryBase;
        protected readonly IDbContext _dbContext;

        public ServiceBase(IDbContext dbContext, IEntityRepository<T> repositoryBase)
        {
            _repositoryBase = repositoryBase;
            _dbContext = dbContext;
        }

        public BusinessResult Add(T entity)
        {
            BusinessResult result = new BusinessResult();

            var id = _repositoryBase.Add(entity);
            _dbContext.Commit();
            if (id > 0)
            {
                result.Code = 1; result.Data = entity; result.Type = "success";
            }
            else
            {
                result.Code = 2; result.Message = "Veri eklenemedi."; result.Type = "warning";
            }
            return result;
        }

        public BusinessResult AddList(IEnumerable<T> entityList)
        {
            BusinessResult result = new BusinessResult();

            var count = _repositoryBase.AddList(entityList); _dbContext.Commit();
            _dbContext.Commit();
            if (count == 0)
            {
                result.Code = 3; result.Message = "Veri eklenemedi"; result.Type = "error";
            }
            else if (count == entityList.Count())
            {
                result.Code = 1; result.Type = "success"; result.Data = entityList;
            }
            else
            {
                result.Code = 2; result.Type = "warning"; result.Data = entityList; result.Message = $"{entityList.Count()} adet objeden {count} obje eklendi.";
            }

            return result;
        }

        public BusinessResult Delete(T entity)
        {
            BusinessResult result = new BusinessResult();

            var isDeleted = _repositoryBase.Delete(entity);
            _dbContext.Commit();
            if (isDeleted)
            {
                result.Code = 1; result.Data = entity; result.Type = "success";
            }
            else
            {
                result.Code = 2; result.Message = "Veri silinmedi."; result.Type = "error";
            }
            return result;
        }

        public BusinessResult DeleteAll()
        {
            BusinessResult result = new BusinessResult();

            var isDeleted = _repositoryBase.DeleteAll();
            _dbContext.Commit();
            if (isDeleted)
            {
                result.Code = 1; result.Type = "success";
            }
            else
            {
                result.Code = 2; result.Message = "Veri silinmedi."; result.Type = "error";
            }
            return result;
        }

        public BusinessResult DeleteList(IEnumerable<T> entityList)
        {
            BusinessResult result = new BusinessResult();

            var isDeleted = _repositoryBase.DeleteList(entityList);
            _dbContext.Commit();
            if (isDeleted)
            {
                result.Code = 1; result.Type = "success";
            }
            else
            {
                result.Code = 2; result.Message = "Veri silinmedi."; result.Type = "error";
            }
            return result;
        }
        public BusinessResult Get(int Id)
        {
            BusinessResult result = new BusinessResult();

            var entity = _repositoryBase.Get(Id);
            _dbContext.Commit();
            if (entity != null)
            {
                result.Code = 1; result.Type = "success"; result.Data = entity;
            }
            else
            {
                result.Code = 2; result.Message = "Veri bulumadı."; result.Type = "error";
            }
            return result;
        }

        public BusinessResult GetAll()
        {
            BusinessResult result = new BusinessResult();

            var entityList = _repositoryBase.GetAll();
            _dbContext.Commit();
            if (entityList != null)
            {
                result.Code = 1; result.Type = "success"; result.Data = entityList;
            }
            else
            {
                result.Code = 2; result.Message = "Veri bulumadı."; result.Type = "error";
            }
            return result;
        }

        public BusinessResult Update(T entity)
        {
            BusinessResult result = new BusinessResult();

            var isUpdated = _repositoryBase.Update(entity);
            _dbContext.Commit();
            if (isUpdated)
            {
                result.Code = 1; result.Type = "success"; result.Data = entity;
            }
            else
            {
                result.Code = 2; result.Message = "Veri güncellenemedi."; result.Type = "error";
            }
            return result;
        }
        
        public BusinessResult UpdateList(IEnumerable<T> entityList)
        {
            BusinessResult result = new BusinessResult();

            var isUpdated = _repositoryBase.UpdateList(entityList);
            _dbContext.Commit();
            if (isUpdated)
            {
                result.Code = 1; result.Type = "success"; result.Data = entityList;
            }
            else
            {
                result.Code = 2; result.Message = "Veri güncellenemedi."; result.Type = "error";
            }
            return result;
        }
    }
}