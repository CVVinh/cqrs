using cqrs_vhec.Data;
using cqrs_vhec.Module.Postgre.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace cqrs_vhec.Service.Postgre
{
    public interface ITypeProductPgService : IPostgreRepo<TypeProductPg>
    {
        //Task<IEnumerable<TypeProductPg>> GetAll(Func<IQueryable<TypeProductPg>, IIncludableQueryable<TypeProductPg, object>> entity = null);
        //Task<TypeProductPg?> GetById(Expression<Func<TypeProductPg, bool>> expression, Func<IQueryable<TypeProductPg>, IIncludableQueryable<TypeProductPg, object>> entity = null);
        //IEnumerable<TypeProductPg> Find(Expression<Func<TypeProductPg, bool>> expression);
        //Task<TypeProductPg> Insert(TypeProductPg entity);
        //Task<TypeProductPg> Update(TypeProductPg entity);
        //Task<TypeProductPg> Delete(TypeProductPg entity);

    }
    public class TypeProductPgService : PostgreRepo<TypeProductPg>, ITypeProductPgService
    {
        private readonly PostgreDBContext _dbContext;

        public TypeProductPgService(PostgreDBContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }

        //public async Task<TypeProductPg> Delete(TypeProductPg entity)
        //{
        //    _dbContext.Remove(entity);
        //    await _dbContext.SaveChangesAsync();
        //    return entity;
        //}

        //public IEnumerable<TypeProductPg> Find(Expression<Func<TypeProductPg, bool>> expression)
        //{
        //    return _dbContext.TypeProductPgs.Where(expression);
        //}

        //public async Task<IEnumerable<TypeProductPg>> GetAll(Func<IQueryable<TypeProductPg>, IIncludableQueryable<TypeProductPg, object>> entity = null)
        //{
        //    if (entity == null)
        //    {
        //        return await _dbContext.TypeProductPgs.ToListAsync();
        //    }
        //    return await entity(_dbContext.TypeProductPgs.AsQueryable()).ToListAsync();
        //}

        //public async Task<TypeProductPg?> GetById(Expression<Func<TypeProductPg, bool>> expression, Func<IQueryable<TypeProductPg>, IIncludableQueryable<TypeProductPg, object>> entity = null)
        //{
        //    if (entity == null)
        //    {
        //        return await _dbContext.TypeProductPgs.Where(expression).FirstOrDefaultAsync();
        //    }
        //    return await entity(_dbContext.TypeProductPgs.AsQueryable()).Where(expression).FirstOrDefaultAsync();
        //}

        //public async Task<TypeProductPg> Insert(TypeProductPg entity)
        //{
        //    await _dbContext.TypeProductPgs.AddAsync(entity);
        //    await _dbContext.SaveChangesAsync();
        //    return entity;
        //}

        //public async Task<TypeProductPg> Update(TypeProductPg entity)
        //{
        //    _dbContext.Update(entity);
        //    await _dbContext.SaveChangesAsync();
        //    return entity;
        //}
        //public bool IsEntity(Expression<Func<TypeProductPg, bool>> expression)
        //{
        //    return _dbContext.TypeProductPgs.Any(expression);
        //}
    }
}
