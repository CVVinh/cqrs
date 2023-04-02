using cqrs_vhec.Data;
using cqrs_vhec.Module.Mongo;
using cqrs_vhec.Module.Postgre.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace cqrs_vhec.Service.Postgre
{
    public interface IProductPgService : IPostgreRepo<ProductPg>
    {
        //Task<IEnumerable<ProductPg>> GetAll(Func<IQueryable<ProductPg>, IIncludableQueryable<ProductPg, object>> entity = null);
        //Task<ProductPg?> GetById(Expression<Func<ProductPg, bool>> expression, Func<IQueryable<ProductPg>, IIncludableQueryable<ProductPg, object>> entity = null);
        //IEnumerable<ProductPg> Find(Expression<Func<ProductPg, bool>> expression);
        //Task<ProductPg> Insert(ProductPg entity);
        //Task<ProductPg> Update(ProductPg entity);
        //Task<ProductPg> Delete(ProductPg entity);
        
    }
    public class ProductPgService : PostgreRepo<ProductPg>, IProductPgService
    {
        private readonly PostgreDBContext _dbContext;

        public ProductPgService(PostgreDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        //public async Task<IEnumerable<ProductPg>> GetAll(Func<IQueryable<ProductPg>, IIncludableQueryable<ProductPg, object>> entity = null)
        //{
        //    if (entity == null)
        //    {
        //        return await _dbContext.ProductPgs.ToListAsync();
        //    }
        //    return await entity(_dbContext.ProductPgs.AsQueryable()).ToListAsync();
        //}

        //public IEnumerable<ProductPg> Find(Expression<Func<ProductPg, bool>> expression)
        //{
        //    return _dbContext.ProductPgs.Where(expression);
        //}
       
        //public async Task<ProductPg?> GetById(Expression<Func<ProductPg, bool>> expression, Func<IQueryable<ProductPg>, IIncludableQueryable<ProductPg, object>> entity = null)
        //{
        //    if (entity == null)
        //    {
        //        return await _dbContext.ProductPgs.Where(expression).FirstOrDefaultAsync();
        //    }
        //    return await entity(_dbContext.ProductPgs.AsQueryable()).Where(expression).FirstOrDefaultAsync();
        //}

        //public async Task<ProductPg> Insert(ProductPg entity)
        //{
        //    await _dbContext.ProductPgs.AddAsync(entity);
        //    await _dbContext.SaveChangesAsync();
        //    return entity;
        //}

        //public async Task<ProductPg> Update(ProductPg entity)
        //{
        //    _dbContext.Update(entity);
        //    await _dbContext.SaveChangesAsync();
        //    return entity;
        //}

        //public async Task<ProductPg> Delete(ProductPg entity)
        //{
        //    _dbContext.Remove(entity);
        //    await _dbContext.SaveChangesAsync();
        //    return entity;
        //}
        //public bool IsEntity(Expression<Func<ProductPg, bool>> expression)
        //{
        //    return _dbContext.ProductPgs.Any(expression);
        //}

    }
}
