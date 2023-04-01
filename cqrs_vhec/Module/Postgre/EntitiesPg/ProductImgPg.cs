namespace cqrs_vhec.Module.Postgre.Entities
{
    public class ProductImgPg : BaseEntityPostgre
    {
        public string ImgPath { get; set; }

        public int ProductPgId { get; set; }
        public ProductPg ProductPg { get; set; }
    }
}
