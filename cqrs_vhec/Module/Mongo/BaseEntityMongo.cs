using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace cqrs_vhec.Module.Mongo
{
    public class BaseEntityMongo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

    }
}
