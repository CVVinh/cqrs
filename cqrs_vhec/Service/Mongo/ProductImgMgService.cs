using cqrs_vhec.Data;
using cqrs_vhec.Module.Mongo.EntitiesMg;
using MongoDB.Driver;

namespace cqrs_vhec.Service.Mongo
{
    public interface IProductImgMgService
    {
        Task<List<ProductImgMg>> GetAll();
        Task<ProductImgMg> GetById(int id);
        Task<ProductImgMg> Create(ProductImgMg entity);
        Task<bool> Update(int id, ProductImgMg entity);
        Task<bool> Delete(int id);
    }

    public class ProductImgMgService : IProductImgMgService
    {
        private readonly IMongoCollection<ProductImgMg> _mongoCollection;

        public ProductImgMgService(MongoDBContext context)
        {
            _mongoCollection = context.GetCollection<ProductImgMg>("ProductImg");
        }

        public async Task<ProductImgMg> Create(ProductImgMg entity)
        {
            await _mongoCollection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var deleteResult = await _mongoCollection.DeleteOneAsync(p => p.ProductImgPgId == id);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<List<ProductImgMg>> GetAll()
        {
            return await _mongoCollection.Find(entity => true).ToListAsync();
        }

        public async Task<ProductImgMg> GetById(int id)
        {
            return await _mongoCollection.Find(entity => entity.ProductImgPgId == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Update(int id, ProductImgMg entity)
        {
            var updateResult = await _mongoCollection.ReplaceOneAsync(filter: p => p.ProductImgPgId == id, replacement: entity);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
