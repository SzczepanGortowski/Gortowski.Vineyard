using Gortowski.Vineyard.Interfaces.DAO;
using Gortowski.Vineyard.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Gortowski.Vineyard.DAO

{
    internal class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private IDataContext _db;
        public Repository(IDataContext db)
        {
            _db = db;
        }

        public virtual void Delete(int id)
        {
            var entity = GetEntity(id);
            _db.GetContext<TEntity>().Remove(entity);
            _db.DeleteEntity(entity);
        }
        public TEntity GetByID(Expression<Func<TEntity, bool>> predicate)

        {
            var query = _db.GetContext<TEntity>().AsQueryable();
            query = query.Where(predicate);

            var tmp = query.FirstOrDefault();
            return tmp;
        }
        public virtual IEnumerable<TEntity> GetList(
            Expression<Func<TEntity, bool>> filter = null)
        {
            var query = _db.GetContext<TEntity>().AsQueryable();
            if (filter != null)
            {
                query = query.Where(filter);
            }

            var result = query.ToList();
            return result;
        }
        public void Insert(TEntity entity)
        {
            _db.GetContext<TEntity>().Add(entity);
            _db.AddEntity(entity);
        }
        public virtual void Update(TEntity entity)
        {
            _db.GetContext<TEntity>()[_db.GetContext<TEntity>().IndexOf(GetEntity(entity.Id))] = entity;
            _db.UpdateEntity(entity);
        }
        private TEntity GetEntity(int id) => _db.GetContext<TEntity>().FirstOrDefault(x => x.Id == id);
    }
}