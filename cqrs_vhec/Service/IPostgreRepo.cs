using cqrs_vhec.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace cqrs_vhec.Service
{
    public interface IPostgreRepo<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> entity = null);
        Task<TEntity?> GetById(Expression<Func<TEntity, bool>> expression, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> entity = null);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
        Task<TEntity?> Insert(TEntity entity);
        Task<TEntity?> Update(TEntity entity);
        Task<TEntity?> Delete(TEntity entity);
        bool IsEntity(Expression<Func<TEntity, bool>> expression);
    }

    public class PostgreRepo<TEntity> : IPostgreRepo<TEntity> where TEntity : class
    {
        private PostgreDBContext _context;
        private DbSet<TEntity> dbSet;

        public PostgreRepo(PostgreDBContext context)
        {
            _context = context;
            dbSet = _context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAll(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> entity = null)
        {
            if (entity == null)
            {
                return await dbSet.ToListAsync();
            }
            return await entity(dbSet.AsQueryable()).ToListAsync();
        }

        public async Task<TEntity?> GetById(Expression<Func<TEntity, bool>> expression, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> entity = null)
        {
            if (entity == null)
            {
                return await dbSet.Where(expression).FirstOrDefaultAsync();
            }
            return await entity(dbSet.AsQueryable()).Where(expression).FirstOrDefaultAsync();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        {
            return dbSet.Where(expression);
        }

        public async Task<TEntity?> Insert(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }


        public async Task<TEntity?> Update(TEntity entity)
        {
            dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity?> Delete(TEntity entity)
        {
            dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public bool IsEntity(Expression<Func<TEntity, bool>> expression)
        {
            return dbSet.Any(expression);
        }
    }


}
