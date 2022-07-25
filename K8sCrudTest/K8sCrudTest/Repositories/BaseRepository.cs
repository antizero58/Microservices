using Microsoft.EntityFrameworkCore;
using Repository.Base;
using System.Linq.Expressions;

namespace K8sCrudTest
{
    public class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(IRepositoryContext context)
        {
            _dbContext = context.DataContext;

            if (_dbContext != null)
                _dbSet = _dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> Get()
        {
            return _dbSet;
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public TEntity Find(params object[] keyValues)
        {
            return _dbSet.Find(keyValues);
        }

        public virtual IEnumerable<TEntity> List()
        {
            return _dbSet.AsEnumerable();
        }

        public virtual IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet
                   .Where(predicate)
                   .AsEnumerable();
        }

        public void Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(object id)
        {
            var entity = _dbSet.Find(id);
            Delete(entity);
        }
    }
}
