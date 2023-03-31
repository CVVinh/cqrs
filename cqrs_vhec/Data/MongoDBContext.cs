using MongoDB.Driver;

namespace cqrs_vhec.Data
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database;

        public MongoDBContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDatabase"));
            _database = client.GetDatabase(configuration.GetSection("MongoDb:DatabaseName").Value);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _database.GetCollection<T>(name);
        }

    }
}
