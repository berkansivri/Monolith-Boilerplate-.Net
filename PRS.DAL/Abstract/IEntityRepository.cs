using PRS.Entities.Abstract;
using System.Collections.Generic;

namespace PRS.DAL.Abstract
{
    public interface IEntityRepository<T> where T:class, IEntity, new()
    {
        long Add(T entity);

        long AddList(IEnumerable<T> EntityList);

        bool Update(T entity);

        bool UpdateList(IEnumerable<T> EntityList);

        bool Delete(T entity);

        bool DeleteList(IEnumerable<T> EntityList);

        bool DeleteAll();

        T Get(int Id);

        IEnumerable<T> GetAll();
    }
}