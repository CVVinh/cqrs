using AutoMapper;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Service.Postgre;
using MediatR;

namespace cqrs_vhec.Request.Command.PostgreCM
{
    public class CreateInformationTypeProductPgCommand : IRequest<InformationTypeProductPg>
    {
        public int TypeProductPgId { get; set; }

        public CreateInformationTypeProductPgCommand()
        {
        }
        public CreateInformationTypeProductPgCommand(CreateInformationTypeProductPgCommand createInformationTypeProductPgCommand)
        {
            this.TypeProductPgId = createInformationTypeProductPgCommand.TypeProductPgId;
        }

        public CreateInformationTypeProductPgCommand(int InformationProductPgId, int TypeProductPgId)
        {
            this.TypeProductPgId = TypeProductPgId;
        }
    }

    public class CreateInformationTypeProductPgHandler : IRequestHandler<CreateInformationTypeProductPgCommand, InformationTypeProductPg>
    {
        private readonly IInformationTypeProductPgService _informationTypeProductPgService;
        private readonly IMapper _mapper;

        public CreateInformationTypeProductPgHandler(IInformationTypeProductPgService informationTypeProductPgService, IMapper mapper)
        {
            _informationTypeProductPgService = informationTypeProductPgService;
            _mapper = mapper;
        }

        public async Task<InformationTypeProductPg> Handle(CreateInformationTypeProductPgCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mapDataPg = _mapper.Map<InformationTypeProductPg>(request);
                var result = await _informationTypeProductPgService.Insert(mapDataPg);
                return mapDataPg;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}
