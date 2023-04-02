using AutoMapper;
using cqrs_vhec.Module.Mongo.EntitiesMg;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Request.DTOs;
using cqrs_vhec.Service.Mongo;
using cqrs_vhec.Service.Postgre;
using MediatR;
using System.Text.Json.Serialization;

namespace cqrs_vhec.Request.Command.PostgreCM
{
    public class CreateDetailInformationTypeProductPgCommand : IRequest<DetailInformationTypeProductPg>
    {
        public string? Content { get; set; }

        public int InformationTypeProductPgId { get; set; }

        public int ProductPgId { get; set; }

        public CreateDetailInformationTypeProductPgCommand(CreateDetailInformationTypeProductPgCommand createDetailInformationTypeProductPgCommand)
        {
            this.InformationTypeProductPgId = createDetailInformationTypeProductPgCommand.InformationTypeProductPgId;
            this.ProductPgId = createDetailInformationTypeProductPgCommand.ProductPgId;
            this.Content = createDetailInformationTypeProductPgCommand.Content;
        }

        [JsonConstructor]
        public CreateDetailInformationTypeProductPgCommand(int InformationTypeProductPgId, int ProductPgId, string? Content)
        {
            this.InformationTypeProductPgId = InformationTypeProductPgId;
            this.ProductPgId = ProductPgId;
            this.Content = Content;
        }
    }

    public class CreateDetailInformationTypeProductPgHandler : IRequestHandler<CreateDetailInformationTypeProductPgCommand, DetailInformationTypeProductPg>
    {
        private readonly IDetailInformationTypeProductPgService _detailInformationTypeProductPgService;
        private readonly IDetailInformationTypeProductMgService _detailInformationTypeProductMgService;
        private readonly IMapper _mapper;

        public CreateDetailInformationTypeProductPgHandler(IDetailInformationTypeProductPgService detailInformationTypeProductPgService, IDetailInformationTypeProductMgService detailInformationTypeProductMgService, IMapper mapper)
        {
            _detailInformationTypeProductPgService = detailInformationTypeProductPgService;
            _detailInformationTypeProductMgService = detailInformationTypeProductMgService;
            _mapper = mapper;
        }

        public async Task<DetailInformationTypeProductPg> Handle(CreateDetailInformationTypeProductPgCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mapDataPg = _mapper.Map<DetailInformationTypeProductPg>(request);
                var result = await _detailInformationTypeProductPgService.Insert(mapDataPg);

                var objectMg = new DetailInformationTypeProductMg()
                {
                    DetailInformationTypeProductMgId = result.Id,
                    InformationTypeProductMgId = mapDataPg.InformationTypeProductPgId,
                    ProductMgId = mapDataPg.ProductPgId,
                    Content = mapDataPg.Content,
                };
                await _detailInformationTypeProductMgService.Create(objectMg);
                return mapDataPg;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}
