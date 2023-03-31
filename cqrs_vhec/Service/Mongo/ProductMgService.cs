using cqrs_vhec.Data;
using cqrs_vhec.Module.Mongo;
using MongoDB.Driver;

namespace cqrs_vhec.Service.Mongo
{
    public interface IProductMgService
    {
        Task<List<ProductMg>> GetAll();
        Task<ProductMg> GetById(int id);
        Task<ProductMg> Create(ProductMg product);
        Task<bool> Update(int id, ProductMg product);
        Task<bool> Delete(int id);
    }

    public class ProductMgService : IProductMgService
    {
        private readonly IMongoCollection<ProductMg> _mongoCollection;

        public ProductMgService(MongoDBContext context)
        {
            _mongoCollection = context.GetCollection<ProductMg>("Product");
        }

        public async Task<List<ProductMg>> GetAll()
        {
            return await _mongoCollection.Find(product => true).ToListAsync();
        }

        public async Task<ProductMg> GetById(int id)
        {
            return _mongoCollection.Find(product => product.IdProject == id).FirstOrDefault();
        }

        public async Task<ProductMg> Create(ProductMg product)
        {
            await _mongoCollection.InsertOneAsync(product);
            return product;
        }

        public async Task<bool> Update(int id, ProductMg product)
        {
            var updateResult = await _mongoCollection.ReplaceOneAsync(filter: p => p.IdProject == id, replacement: product);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var deleteResult = await _mongoCollection.DeleteOneAsync(p => p.IdProject == id);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }


    }

}
