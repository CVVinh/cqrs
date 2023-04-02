using cqrs_vhec.Data;
using cqrs_vhec.Module.Mongo.EntitiesMg;
using MongoDB.Driver;

namespace cqrs_vhec.Service.Mongo
{
    public interface ITypeProductMgService
    {
        Task<List<TypeProductMg>> GetAll();
        Task<TypeProductMg> GetById(int id);
        Task<TypeProductMg> Create(TypeProductMg entity);
        Task<bool> Update(int id, TypeProductMg entity);
        Task<bool> Delete(int id);
    }

    public class TypeProductMgService : ITypeProductMgService
    {
        private readonly IMongoCollection<TypeProductMg> _mongoCollection;

        public TypeProductMgService(MongoDBContext context)
        {
            _mongoCollection = context.GetCollection<TypeProductMg>("TypeProduct");
        }


        public async Task<TypeProductMg> Create(TypeProductMg entity)
        {
            await _mongoCollection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var deleteResult = await _mongoCollection.DeleteOneAsync(p => p.TypeProductPgId == id);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<List<TypeProductMg>> GetAll()
        {
            return await _mongoCollection.Find(entity => true).ToListAsync();
        }

        public async Task<TypeProductMg> GetById(int id)
        {
            return await _mongoCollection.Find(entity => entity.TypeProductPgId == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Update(int id, TypeProductMg entity)
        {
            var updateResult = await _mongoCollection.ReplaceOneAsync(filter: p => p.TypeProductPgId == id, replacement: entity);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
