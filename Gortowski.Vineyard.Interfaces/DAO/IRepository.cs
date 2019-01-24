using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Gortowski.Vineyard.Interfaces.DAO
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetByID(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetList(
            Expression<Func<TEntity, bool>> filter = null);
        void Insert(TEntity entity);
        void Delete(int id);
        void Update(TEntity entity);
    }
}