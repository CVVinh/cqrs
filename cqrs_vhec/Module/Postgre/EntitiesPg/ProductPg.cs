using System.ComponentModel.DataAnnotations;

namespace cqrs_vhec.Module.Postgre.Entities
{
    public class ProductPg : BaseEntityPostgre
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public int TypeProductPgId { get; set; }
        public TypeProductPg TypeProductPg { get; set; }

        public ICollection<DetailInformationTypeProductPg>? DetailInformationTypeProductPg { get; set; }
        public ICollection<ProductImgPg>? ProductImgPg { get; set; }

        public ProductPg()
        {
            this.DetailInformationTypeProductPg = new HashSet<DetailInformationTypeProductPg>();
            this.ProductImgPg = new HashSet<ProductImgPg>();
        }
    }
}
