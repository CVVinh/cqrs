using AutoMapper;
using cqrs_vhec.Module.Mongo.EntitiesMg;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Request.DTOs;
using cqrs_vhec.Service.Mongo;
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
        private readonly IInformationProductMgService _informationProductMgService;
        private readonly IMapper _mapper;

        public CreateInformationProductPgHandler(IInformationProductPgService informationProductPgService, IInformationProductMgService informationProductMgService, IMapper mapper)
        {
            _informationProductPgService = informationProductPgService;
            _informationProductMgService = informationProductMgService;
            _mapper = mapper;
        }

        public async Task<InformationProductPg> Handle(CreateInformationProductPgCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mapDataPg = _mapper.Map<InformationProductPg>(request);
                var result = await _informationProductPgService.Insert(mapDataPg);
                if (result != null)
                {
                    var arrInfoTypeProduct = new List<InformationTypeProductMg>();
                    foreach (var item in result.InformationTypeProductPg)
                    {
                        var objItem = new InformationTypeProductMg()
                        {
                            InformationTypeProductPgId = item.Id,
                            InformationProductMgId = item.InformationProductPgId,
                            TypeProductMgId = item.TypeProductPgId,
                        };
                        arrInfoTypeProduct.Add(objItem);
                    }

                    var objectMg = new InformationProductMg()
                    {
                        InformationProductPgId = result.Id,
                        Name = result.Name,
                        Description = result.Description,
                        InformationTypeProductMg = arrInfoTypeProduct,
                    };
                    await _informationProductMgService.Create(objectMg);
                }

                return mapDataPg;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}
