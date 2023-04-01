using System.ComponentModel.DataAnnotations;

namespace cqrs_vhec.Module.Postgre.Entities
{
    public class InformationTypeProductPg : BaseEntityPostgre
    {
        public int InformationProductPgId { get; set; }
        public int TypeProductPgId { get; set; }

        public TypeProductPg TypeProductPg { get; set; }
        public InformationProductPg InformationProductPg { get; set; }

        public ICollection<DetailInformationTypeProductPg>? DetailInformationTypeProductPg { get; set; }

        public InformationTypeProductPg()
        {
            this.DetailInformationTypeProductPg = new HashSet<DetailInformationTypeProductPg>();
        }
    }
}
