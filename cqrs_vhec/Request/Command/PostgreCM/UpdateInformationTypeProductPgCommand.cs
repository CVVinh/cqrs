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
    public class UpdateInformationTypeProductPgCommand : IRequest<InformationTypeProductPg>
    {
        public int Id { get; set; }
        public int TypeProductPgId { get; set; }
        public int InformationProductPgId { get; set; }

        public UpdateInformationTypeProductPgCommand()
        {
        }
        public UpdateInformationTypeProductPgCommand(UpdateInformationTypeProductPgCommand updateInformationTypeProductPgCommand)
        {
            this.Id = updateInformationTypeProductPgCommand.Id;
            this.TypeProductPgId = updateInformationTypeProductPgCommand.TypeProductPgId;
            this.InformationProductPgId = updateInformationTypeProductPgCommand.InformationProductPgId;
        }

        [JsonConstructor]
        public UpdateInformationTypeProductPgCommand(int Id, int InformationProductPgId, int TypeProductPgId)
        {
            this.Id = Id;
            this.TypeProductPgId = TypeProductPgId;
            this.InformationProductPgId = InformationProductPgId;
        }
    }

    public class UpdateInformationTypeProductPgHandler : IRequestHandler<UpdateInformationTypeProductPgCommand, InformationTypeProductPg>
    {
        private readonly IInformationTypeProductPgService _informationTypeProductPgService;
        private readonly IInformationTypeProductMgService _informationTypeProductMgService;
        private readonly IMapper _mapper;

        public UpdateInformationTypeProductPgHandler(IInformationTypeProductPgService informationTypeProductPgService, IInformationTypeProductMgService informationTypeProductMgService, IMapper mapper)
        {
            _informationTypeProductPgService = informationTypeProductPgService;
            _informationTypeProductMgService = informationTypeProductMgService;
            _mapper = mapper;
        }

        public async Task<InformationTypeProductPg> Handle(UpdateInformationTypeProductPgCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingEntity = await _informationTypeProductPgService.GetById(s => s.Id.Equals(request.Id), s => s.Include(s => s.InformationProductPg).Include(s => s.TypeProductPg));
                if (existingEntity == null)
                {
                    return null;
                }
                var mapData = _mapper.Map(request, existingEntity);
                await _informationTypeProductPgService.Update(mapData);
                await _informationTypeProductPgService.SubmitSaveAsync();

                // update mongo
                var findMongo = await _informationTypeProductMgService.GetById(existingEntity.Id);
                if (findMongo != null)
                {
                    var objectMg = new InformationTypeProductMg()
                    {
                        Id = findMongo.Id,
                        InformationTypeProductPgId = findMongo.InformationTypeProductPgId,
                        InformationProductMgId = mapData.InformationProductPgId,
                        TypeProductMgId = mapData.TypeProductPgId,
                    };

                    var updateMongo = await _informationTypeProductMgService.Update(existingEntity.Id, objectMg);
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
