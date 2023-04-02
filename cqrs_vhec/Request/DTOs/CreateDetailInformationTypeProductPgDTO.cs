namespace cqrs_vhec.Request.DTOs
{
    public class CreateDetailInformationTypeProductPgDTO
    {
        public string? Content { get; set; }

        public int InformationTypeProductPgId { get; set; }

        public CreateDetailInformationTypeProductPgDTO () { }

        public CreateDetailInformationTypeProductPgDTO (CreateDetailInformationTypeProductPgDTO createDetailInformationTypeProductPgDTO) 
        {
            this.InformationTypeProductPgId = createDetailInformationTypeProductPgDTO.InformationTypeProductPgId;
            this.Content = createDetailInformationTypeProductPgDTO.Content;

        }

        public CreateDetailInformationTypeProductPgDTO (int InformationTypeProductPgId, string? Content) 
        {
            this.InformationTypeProductPgId = InformationTypeProductPgId;
            this.Content = Content;
        }
    }
}
