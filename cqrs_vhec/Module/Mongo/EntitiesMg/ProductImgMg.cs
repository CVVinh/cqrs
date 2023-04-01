using cqrs_vhec.Module.Postgre.Entities;
using MongoDB.Bson.Serialization.Attributes;

namespace cqrs_vhec.Module.Mongo.EntitiesMg
{
    public class ProductImgMg : BaseEntityMongo
    {
        [BsonElement("ProductImgPgId")]
        public int ProductImgPgId { get; set; }

        [BsonElement("ImgPath")]
        public string ImgPath { get; set; }

        [BsonElement("ProductMgId")]
        public int ProductMgId { get; set; }
    }
}
