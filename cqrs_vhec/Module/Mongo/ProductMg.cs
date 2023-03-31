
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace cqrs_vhec.Module.Mongo
{
    public class ProductMg
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("IdProject")]
        public int IdProject { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Description")]
        public string? Description { get; set; }
    }
}
