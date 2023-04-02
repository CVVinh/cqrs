using MongoDB.Bson.Serialization.Attributes;

namespace cqrs_vhec.Module.Mongo.EntitiesMg
{
    public class DetailInformationTypeProductMg : BaseEntityMongo
    {
        [BsonElement("DetailInformationTypeProductPgId")]
        public int DetailInformationTypeProductPgId { get; set; }

        [BsonElement("InformationTypeProductMgId")]
        public int InformationTypeProductMgId { get; set; }

        [BsonElement("ProductMgId")]
        public int ProductMgId { get; set; }

        [BsonElement("Content")]
        public string Content { get; set; }

    }
}
