using cqrs_vhec.Data;
using cqrs_vhec.Module.Mongo.EntitiesMg;
using MongoDB.Driver;

namespace cqrs_vhec.Service.Mongo
{
    public interface IInformationTypeProductMgService
    {
        Task<List<InformationTypeProductMg>> GetAll();
        Task<InformationTypeProductMg> GetById(int id);
        Task<InformationTypeProductMg> Create(InformationTypeProductMg entity);
        Task<bool> Update(int id, InformationTypeProductMg entity);
        Task<bool> Delete(int id);
    }

    public class InformationTypeProductMgService : IInformationTypeProductMgService
    {
        private readonly IMongoCollection<InformationTypeProductMg> _mongoCollection;

        public InformationTypeProductMgService(MongoDBContext context)
        {
            _mongoCollection = context.GetCollection<InformationTypeProductMg>("InformationTypeProduct");
        }

        public async Task<InformationTypeProductMg> Create(InformationTypeProductMg entity)
        {
            await _mongoCollection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var deleteResult = await _mongoCollection.DeleteOneAsync(p => p.InformationTypeProductPgId == id);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<List<InformationTypeProductMg>> GetAll()
        {
            return await _mongoCollection.Find(entity => true).ToListAsync();
        }

        public async Task<InformationTypeProductMg> GetById(int id)
        {
            return _mongoCollection.Find(entity => entity.InformationTypeProductPgId == id).FirstOrDefault();
        }

        public async Task<bool> Update(int id, InformationTypeProductMg entity)
        {
            var updateResult = await _mongoCollection.ReplaceOneAsync(filter: p => p.InformationTypeProductPgId == id, replacement: entity);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
