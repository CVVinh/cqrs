using AutoMapper;
using cqrs_vhec.Module.Mongo.EntitiesMg;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Service.Mongo;
using cqrs_vhec.Service.Postgre;
using MediatR;
using System.Text.Json.Serialization;

namespace cqrs_vhec.Request.Command.PostgreCM
{
    public class CreateInformationTypeProductPgCommand : IRequest<InformationTypeProductPg>
    {
        public int TypeProductPgId { get; set; }
        public int InformationProductPgId { get; set; }

        public CreateInformationTypeProductPgCommand()
        {
        }
        public CreateInformationTypeProductPgCommand(CreateInformationTypeProductPgCommand createInformationTypeProductPgCommand)
        {
            this.TypeProductPgId = createInformationTypeProductPgCommand.TypeProductPgId;
            this.InformationProductPgId = createInformationTypeProductPgCommand.InformationProductPgId;
        }

        [JsonConstructor]
        public CreateInformationTypeProductPgCommand(int InformationProductPgId, int TypeProductPgId)
        {
            this.TypeProductPgId = TypeProductPgId;
            this.InformationProductPgId = InformationProductPgId;
        }
    }

    public class CreateInformationTypeProductPgHandler : IRequestHandler<CreateInformationTypeProductPgCommand, InformationTypeProductPg>
    {
        private readonly IInformationTypeProductPgService _informationTypeProductPgService;
        private readonly IInformationTypeProductMgService _informationTypeProductMgService;
        private readonly IMapper _mapper;

        public CreateInformationTypeProductPgHandler(IInformationTypeProductPgService informationTypeProductPgService, IInformationTypeProductMgService informationTypeProductMgService, IMapper mapper)
        {
            _informationTypeProductPgService = informationTypeProductPgService;
            _informationTypeProductMgService = informationTypeProductMgService;
            _mapper = mapper;
        }

        public async Task<InformationTypeProductPg> Handle(CreateInformationTypeProductPgCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mapData = _mapper.Map<InformationTypeProductPg>(request);
                var result = await _informationTypeProductPgService.Insert(mapData);

                var objectMg = new InformationTypeProductMg()
                {
                    InformationTypeProductPgId = result.Id,
                    InformationProductMgId = mapData.InformationProductPgId,
                    TypeProductMgId = mapData.TypeProductPgId,
                };
                await _informationTypeProductMgService.Create(objectMg);
                return mapData;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}
