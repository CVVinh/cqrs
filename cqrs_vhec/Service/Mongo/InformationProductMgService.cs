using cqrs_vhec.Data;
using cqrs_vhec.Module.Mongo.EntitiesMg;
using MongoDB.Driver;

namespace cqrs_vhec.Service.Mongo
{
    public interface IInformationProductMgService
    {
        Task<List<InformationProductMg>> GetAll();
        Task<InformationProductMg> GetById(int id);
        Task<InformationProductMg> Create(InformationProductMg entity);
        Task<bool> Update(int id, InformationProductMg entity);
        Task<bool> Delete(int id);
    }

    public class InformationProductMgService : IInformationProductMgService
    {
        private readonly IMongoCollection<InformationProductMg> _mongoCollection;

        public InformationProductMgService(MongoDBContext context)
        {
            _mongoCollection = context.GetCollection<InformationProductMg>("InfomationProduct");
        }


        public async Task<InformationProductMg> Create(InformationProductMg entity)
        {
            await _mongoCollection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var deleteResult = await _mongoCollection.DeleteOneAsync(p => p.InformationProductPgId == id);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<List<InformationProductMg>> GetAll()
        {
            return await _mongoCollection.Find(entity => true).ToListAsync();
        }

        public async Task<InformationProductMg> GetById(int id)
        {
            return await _mongoCollection.Find(entity => entity.InformationProductPgId == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Update(int id, InformationProductMg entity)
        {
            var updateResult = await _mongoCollection.ReplaceOneAsync(filter: p => p.InformationProductPgId == id, replacement: entity);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
