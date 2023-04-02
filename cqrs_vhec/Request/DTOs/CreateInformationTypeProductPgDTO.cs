using cqrs_vhec.Module.Postgre.Entities;
using MediatR;

namespace cqrs_vhec.Request.DTOs
{
    public class CreateInformationTypeProductPgDTO 
    {
        //public int InformationProductPgId { get; set; }
        public int TypeProductPgId { get; set; }

        public CreateInformationTypeProductPgDTO() { }

        public CreateInformationTypeProductPgDTO(CreateInformationTypeProductPgDTO createInformationTypeProductPgDTO) 
        {
            this.TypeProductPgId = createInformationTypeProductPgDTO.TypeProductPgId;
        }

        public CreateInformationTypeProductPgDTO(int TypeProductPgId)
        {
            this.TypeProductPgId = TypeProductPgId;
        }
    }
}
