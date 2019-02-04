using PRS.BLL.Result;
using PRS.Entities.Abstract;
using System.Collections.Generic;

namespace PRS.BLL.Abstract
{
    public interface IServiceBase<T> where T : class, IEntity, new()
    {
        BusinessResult Add(T entity);

        BusinessResult AddList(IEnumerable<T> EntityList);

        BusinessResult Update(T entity);

        BusinessResult UpdateList(IEnumerable<T> EntityList);

        BusinessResult Delete(T entity);

        BusinessResult DeleteList(IEnumerable<T> EntityList);

        BusinessResult DeleteAll();

        BusinessResult Get(int Id);

        BusinessResult GetAll();
    }
}