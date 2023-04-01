using System.ComponentModel.DataAnnotations;

namespace cqrs_vhec.Module.Postgre.Entities
{
    public class TypeProductPg : BaseEntityPostgre
    {
        public string Name { get; set; }

        public ICollection<ProductPg> ProductPg { get; set; }
        public ICollection<InformationTypeProductPg> InformationTypeProductPg { get; set; }

        public TypeProductPg()
        {
            this.ProductPg = new HashSet<ProductPg>();
            this.InformationTypeProductPg = new HashSet<InformationTypeProductPg>();
        }
    }
}
