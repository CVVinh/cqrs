using cqrs_vhec.Data;
using Microsoft.EntityFrameworkCore;

namespace cqrs_vhec.Service
{
    public interface IUnitOfWork : IDisposable
    {
        IPostgreRepo<TEntity> GetRepository<TEntity>() where TEntity : class;
        Task<int> CommitAsync();
        void Rollback();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly PostgreDBContext _context;
        public Dictionary<Type, object> _reporsitory;

        public UnitOfWork(PostgreDBContext context)
        {
            _context = context;
        }

        public IPostgreRepo<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if(_reporsitory == null )
            {
                _reporsitory = new Dictionary<Type, object>();
            }
            var type = typeof(TEntity);
            if(!_reporsitory.ContainsKey(type))
            {
                _reporsitory[type] = new PostgreRepo<TEntity>(_context);
            }
            return (IPostgreRepo<TEntity>)_reporsitory[type];
        }

        public async Task<int> CommitAsync()
        {
           return await _context.SaveChangesAsync();
        }

        public void Rollback()
        {
            _context.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }

        public void Dispose()
        {
            _context.Dispose();
        }

       
    }

}
