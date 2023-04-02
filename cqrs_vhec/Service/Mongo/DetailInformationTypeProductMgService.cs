using cqrs_vhec.Data;
using cqrs_vhec.Module.Mongo.EntitiesMg;
using MongoDB.Driver;

namespace cqrs_vhec.Service.Mongo
{
    public interface IDetailInformationTypeProductMgService
    {
        Task<List<DetailInformationTypeProductMg>> GetAll();
        Task<DetailInformationTypeProductMg> GetById(int id);
        Task<DetailInformationTypeProductMg> Create(DetailInformationTypeProductMg detail);
        Task<bool> Update(int id, DetailInformationTypeProductMg detail);
        Task<bool> Delete(int id);
    }

    public class DetailInformationTypeProductMgService : IDetailInformationTypeProductMgService
    {
        private readonly IMongoCollection<DetailInformationTypeProductMg> _mongoCollection;

        public DetailInformationTypeProductMgService(MongoDBContext context)
        {
            _mongoCollection = context.GetCollection<DetailInformationTypeProductMg>("DetailInfomationTypeProduct");
        }

        public async Task<DetailInformationTypeProductMg> Create(DetailInformationTypeProductMg detail)
        {
            await _mongoCollection.InsertOneAsync(detail);
            return detail;
        }

        public async Task<bool> Delete(int id)
        {
            var deleteResult = await _mongoCollection.DeleteOneAsync(p => p.DetailInformationTypeProductMgId == id);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<List<DetailInformationTypeProductMg>> GetAll()
        {
            return await _mongoCollection.Find(entity => true).ToListAsync();
        }

        public async Task<DetailInformationTypeProductMg> GetById(int id)
        {
            return _mongoCollection.Find(entity => entity.DetailInformationTypeProductMgId == id).FirstOrDefault();
        }

        public async Task<bool> Update(int id, DetailInformationTypeProductMg detail)
        {
            var updateResult = await _mongoCollection.ReplaceOneAsync(filter: p => p.DetailInformationTypeProductMgId == id, replacement: detail);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
