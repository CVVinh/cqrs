namespace cqrs_vhec.Module.Postgre.Entities
{
    public class DetailInformationTypeProductPg : BaseEntityPostgre
    {
        public string? Content { get; set; }

        public int InformationTypeProductPgId { get; set; }
        public int ProductPgId { get; set; }

        public ProductPg ProductPg { get; set; }
        public InformationTypeProductPg InformationTypeProductPg { get; set; }
    }
}
