using Dapper.Contrib;
using Dapper;
using PRS.Core.UoW.Abstract;
using PRS.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ComponentModel;

namespace PRS.DAL.Concrete.Dapper
{
    public class DpEntityRepositoryBase<TEntity> : RepositoryBase<TEntity>
        where TEntity : class, IEntity, new()
    {
        public DpEntityRepositoryBase(IDbContext dbContext) : base(dbContext)
        {
            var map = new CustomPropertyTypeMap(typeof(TEntity),
                                 (type, columnName) => type.GetProperties().FirstOrDefault(prop => GetDescriptionFromAttribute(prop) == columnName));
            SqlMapper.SetTypeMap(typeof(TEntity), map);
        }
        private string GetDescriptionFromAttribute(MemberInfo member)
        {
            if (member == null) return null;
            var attrib = (DescriptionAttribute)Attribute.GetCustomAttribute(member, typeof(DescriptionAttribute), false);
            return attrib == null ? null : attrib.Description;
        }

        public override long Add(TEntity entity)
        {
            return Db.Insert(entity, Transaction);
        }

        public override long AddList(IEnumerable<TEntity> EntityList)
        {
            return Db.Insert(EntityList, Transaction);
        }

        public override bool Update(TEntity entity)
        {
            return Db.Update(entity, Transaction);
        }

        public override bool UpdateList(IEnumerable<TEntity> EntityList)
        {
            return Db.Update(EntityList, Transaction);
        }

        public override bool Delete(TEntity entity)
        {
            return Db.Delete(entity, Transaction);
        }

        [Obsolete("This method will delete all record in table")]
        public override bool DeleteAll()
        {
            return Db.DeleteAll<TEntity>(Transaction);
        }

        public override bool DeleteList(IEnumerable<TEntity> EntityList)
        {
            return Db.Delete(EntityList, Transaction);
        }

        public override TEntity Get(int Id)
        {
            return Db.Get<TEntity>(Id, Transaction);
        }

        public override IEnumerable<TEntity> GetAll()
        {
            return Db.GetAll<TEntity>(Transaction);
        }
    }
}