using cqrs_vhec.Module.Postgre.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace cqrs_vhec.Module.Mongo.EntitiesMg
{
    public class ProductMg : BaseEntityMongo
    {
        [BsonElement("ProductPgId")]
        public int ProductPgId { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Description")]
        public string? Description { get; set; }

        [BsonElement("Quantity")]
        public int Quantity { get; set; }

        [BsonElement("Price")]
        public int Price { get; set; }

        [BsonElement("TypeProductId")]
        public int TypeProductId { get; set; }

        [BsonElement("ProductImgPg")]
        public List<ProductImgPg> ProductImgPg { get; set; }

        [BsonElement("DetailInformationTypeProductMg")]
        public List<DetailInformationTypeProductMg> DetailInformationTypeProductMg { get; set; }

    }
}
