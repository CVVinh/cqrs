using MongoDB.Bson.Serialization.Attributes;

namespace cqrs_vhec.Module.Mongo.EntitiesMg
{
    public class InformationProductMg : BaseEntityMongo
    {
        [BsonElement("InformationProductPgId")]
        public int InformationProductPgId { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Description")]
        public string? Description { get; set; }

        [BsonElement("InformationTypeProductMg")]
        public List<InformationTypeProductMg> InformationTypeProductMg { get; set; }
    }
}
