using AutoMapper;
using cqrs_vhec.Module.Mongo.EntitiesMg;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Service.Mongo;
using cqrs_vhec.Service.Postgre;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrs_vhec.Request.Command.PostgreCM
{
    public class UpdateInformationProductPgCommand : CreateInformationProductPgCommand
    {
        public int Id { get; set; }
        
        public UpdateInformationProductPgCommand() : base()
        {
        }

        public UpdateInformationProductPgCommand(int Id, CreateInformationProductPgCommand createInformationProductPgCommand) : base(createInformationProductPgCommand)
        {
            this.Id = Id;
        }
    }

    public class UpdateInformationProductPgHandler : IRequestHandler<UpdateInformationProductPgCommand, InformationProductPg>
    {
        private readonly IInformationProductPgService _informationProductPgService;
        private readonly IInformationProductMgService _informationProductMgService;
        private readonly IMapper _mapper;

        public UpdateInformationProductPgHandler(IInformationProductPgService informationProductPgService, IInformationProductMgService informationProductMgService, IMapper mapper)
        {
            _informationProductPgService = informationProductPgService;
            _informationProductMgService = informationProductMgService;
            _mapper = mapper;
        }

        public async Task<InformationProductPg> Handle(UpdateInformationProductPgCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingEntity = await _informationProductPgService.GetById(s => s.Id.Equals(request.Id), s => s.Include(s => s.InformationTypeProductPg));
                if (existingEntity == null)
                {
                    return null;
                }
                var mapData = _mapper.Map(request, existingEntity);
                await _informationProductPgService.Update(mapData);
                await _informationProductPgService.SubmitSaveAsync();

                // update mongo
                var findMongo = await _informationProductMgService.GetById(existingEntity.Id);
                if (findMongo != null)
                {
                    var arrInfoTypeProduct = new List<InformationTypeProductMg>();
                    foreach (var item in mapData.InformationTypeProductPg)
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
                        Id = findMongo.Id,
                        InformationProductPgId = findMongo.InformationProductPgId,
                        Name = mapData.Name,
                        Description = mapData.Description,
                        InformationTypeProductMg = arrInfoTypeProduct,
                    };

                    var updateMongo = await _informationProductMgService.Update(existingEntity.Id, objectMg);
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
