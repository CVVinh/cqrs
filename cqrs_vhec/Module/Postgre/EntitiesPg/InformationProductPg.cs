using System.ComponentModel.DataAnnotations;

namespace cqrs_vhec.Module.Postgre.Entities
{
    public class InformationProductPg : BaseEntityPostgre
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public ICollection<InformationTypeProductPg>? InformationTypeProductPg { get; set; }

        public InformationProductPg()
        {
            this.InformationTypeProductPg = new HashSet<InformationTypeProductPg>();
        }
    }
}
