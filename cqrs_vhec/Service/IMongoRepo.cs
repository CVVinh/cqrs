using cqrs_vhec.Data;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace cqrs_vhec.Service
{
    public interface IMongoRepo<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task<T> AddAsync(T entity);
        Task<bool> UpdateAsync(string id, T entity);
        Task<bool> DeleteAsync(string id);

        Task<T> AddAsync<T>(T entity);

        Task<T?> GetByIdByFun(Expression<Func<T, bool>> expression);
        Task<bool> DeleteByFun(Expression<Func<T, bool>> expression);
        Task<bool> UpdateByFun(T entity, Expression<Func<T, bool>> expression);
    }

    public class MongoRepo<T> : IMongoRepo<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        public MongoRepo(MongoDBContext database)
        {
            _collection = database.GetCollection<T>(typeof(T).Name.ToString());
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
            return await _collection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<bool> UpdateAsync(string id, T entity)
        {
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
            var updateResult = await _collection.ReplaceOneAsync(filter, entity);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
            var deleteResult = await _collection.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<T?> GetByIdByFun(Expression<Func<T, bool>> expression)
        {
            return await _collection.Find(expression).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateByFun(T entity, Expression<Func<T, bool>> expression)
        {
            var updateResult = await _collection.ReplaceOneAsync(filter: expression, replacement: entity);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteByFun(Expression<Func<T, bool>> expression)
        {
            var deleteResult = await _collection.DeleteOneAsync(expression);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<T> AddAsync<T>(T entity)
        {
            throw new NotImplementedException();
        }
    }

}
