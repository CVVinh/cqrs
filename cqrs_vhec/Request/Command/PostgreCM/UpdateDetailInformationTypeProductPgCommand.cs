using AutoMapper;
using cqrs_vhec.Module.Mongo.EntitiesMg;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Service.Mongo;
using cqrs_vhec.Service.Postgre;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace cqrs_vhec.Request.Command.PostgreCM
{
    public class UpdateDetailInformationTypeProductPgCommand : IRequest<DetailInformationTypeProductPg>
    {
        public int Id { get; set; }
        public string? Content { get; set; }

        public int InformationTypeProductPgId { get; set; }

        public int ProductPgId { get; set; }

        public UpdateDetailInformationTypeProductPgCommand(UpdateDetailInformationTypeProductPgCommand updateDetailInformationTypeProductPgCommand)
        {
            this.Id = updateDetailInformationTypeProductPgCommand.Id;
            this.InformationTypeProductPgId = updateDetailInformationTypeProductPgCommand.InformationTypeProductPgId;
            this.ProductPgId = updateDetailInformationTypeProductPgCommand.ProductPgId;
            this.Content = updateDetailInformationTypeProductPgCommand.Content;

        }

        [JsonConstructor]
        public UpdateDetailInformationTypeProductPgCommand(int Id, int InformationTypeProductPgId, int ProductPgId, string? Content)
        {
            this.Id = Id;
            this.InformationTypeProductPgId = InformationTypeProductPgId;
            this.ProductPgId = ProductPgId;
            this.Content = Content;
        }
    }

    public class UpdateDetailInformationTypeProductPgHandler : IRequestHandler<UpdateDetailInformationTypeProductPgCommand, DetailInformationTypeProductPg>
    {
        private readonly IDetailInformationTypeProductPgService _detailInformationTypeProductPgService;
        private readonly IDetailInformationTypeProductMgService _detailInformationTypeProductMgService;
        private readonly IMapper _mapper;

        public UpdateDetailInformationTypeProductPgHandler(IDetailInformationTypeProductPgService detailInformationTypeProductPgService, IDetailInformationTypeProductMgService detailInformationTypeProductMgService, IMapper mapper)
        {
            _detailInformationTypeProductPgService = detailInformationTypeProductPgService;
            _detailInformationTypeProductMgService = detailInformationTypeProductMgService;
            _mapper = mapper;
        }

        public async Task<DetailInformationTypeProductPg> Handle(UpdateDetailInformationTypeProductPgCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingEntity = await _detailInformationTypeProductPgService.GetById(s => s.Id.Equals(request.Id));
                if (existingEntity == null)
                {
                    return null;
                }
                var mapData = _mapper.Map(request, existingEntity);
                await _detailInformationTypeProductPgService.Update(mapData);
                await _detailInformationTypeProductPgService.SubmitSaveAsync();

                // update mongo
                var findMongo = await _detailInformationTypeProductMgService.GetById(existingEntity.Id);
                if (findMongo != null)
                {
                    var objectMg = new DetailInformationTypeProductMg()
                    {
                        Id = findMongo.Id,
                        DetailInformationTypeProductPgId = findMongo.DetailInformationTypeProductPgId,
                        InformationTypeProductMgId = mapData.InformationTypeProductPgId,
                        ProductMgId = mapData.ProductPgId,
                        Content = mapData.Content,
                    };

                    var updateMongo = await _detailInformationTypeProductMgService.Update(existingEntity.Id, objectMg);
                    if (updateMongo == true)
                    {
                        return mapData;
                    }
                    else
                    {
                        return null;
                    }
                }
                return mapData;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}
