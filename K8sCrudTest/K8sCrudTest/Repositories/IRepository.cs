using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Get();
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entity);
        TEntity Find(params object[] keyValues);
        IEnumerable<TEntity> List();
        IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> predicate);
    }
}
