using AutoMapper;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Request.DTOs;
using cqrs_vhec.Service.Postgre;
using MediatR;

namespace cqrs_vhec.Request.Command.PostgreCM
{
    public class CreateInformationProductPgCommand : IRequest<InformationProductPg>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<CreateInformationTypeProductPgDTO>? InformationTypeProductPg { get; set; }

        public CreateInformationProductPgCommand()
        {
        }
        public CreateInformationProductPgCommand(CreateInformationProductPgCommand createInformationProductPgCommand)
        {
            this.Name = createInformationProductPgCommand.Name;
            this.Description = createInformationProductPgCommand.Description;
            this.InformationTypeProductPg = createInformationProductPgCommand.InformationTypeProductPg;
        }

        public CreateInformationProductPgCommand(string Name, string? Description, ICollection<CreateInformationTypeProductPgDTO>? InformationTypeProductPg)
        {
            this.Name = Name;
            this.Description = Description;
            this.InformationTypeProductPg = InformationTypeProductPg;
        }
    }

    public class CreateInformationProductPgHandler : IRequestHandler<CreateInformationProductPgCommand, InformationProductPg>
    {
        private readonly IInformationProductPgService _informationProductPgService;
        private readonly IMapper _mapper;

        public CreateInformationProductPgHandler(IInformationProductPgService informationProductPgService, IMapper mapper)
        {
            _informationProductPgService = informationProductPgService;
            _mapper = mapper;
        }

        public async Task<InformationProductPg> Handle(CreateInformationProductPgCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mapDataPg = _mapper.Map<InformationProductPg>(request);
                var result = await _informationProductPgService.Insert(mapDataPg);
                return mapDataPg;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}
