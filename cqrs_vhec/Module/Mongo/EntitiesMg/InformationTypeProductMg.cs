using cqrs_vhec.Module.Postgre.Entities;
using MongoDB.Bson.Serialization.Attributes;

namespace cqrs_vhec.Module.Mongo.EntitiesMg
{
    public class InformationTypeProductMg : BaseEntityMongo
    {
        [BsonElement("InformationTypeProductMgId")]
        public int InformationTypeProductMgId { get; set; }

        [BsonElement("InformationProductMgId")]
        public int InformationProductMgId { get; set; }

        [BsonElement("TypeProductMgId")]
        public int TypeProductMgId { get; set; }

        [BsonElement("DetailInformationTypeProductMg")]
        public List<DetailInformationTypeProductMg> DetailInformationTypeProductMg { get; set; }
    }
}
