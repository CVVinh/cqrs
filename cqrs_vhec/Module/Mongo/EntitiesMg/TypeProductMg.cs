using cqrs_vhec.Module.Postgre.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace cqrs_vhec.Module.Mongo.EntitiesMg
{
    public class TypeProductMg : BaseEntityMongo
    {
        [BsonElement("TypeProductPgId")]
        public int TypeProductPgId { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("ProductMg")]
        public List<ProductMg> ProductMg { get; set; }

        [BsonElement("InformationTypeProductMg")]
        public List<InformationTypeProductMg> InformationTypeProductMg { get; set; }

    }
}
