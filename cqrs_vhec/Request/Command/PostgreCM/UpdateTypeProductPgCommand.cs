using AutoMapper;
using cqrs_vhec.Module.Mongo.EntitiesMg;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Request.Query;
using cqrs_vhec.Service.Mongo;
using cqrs_vhec.Service.Postgre;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrs_vhec.Request.Command.PostgreCM
{
    public class UpdateTypeProductPgCommand : IRequest<TypeProductPg>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public UpdateTypeProductPgCommand()
        {
        }

        public UpdateTypeProductPgCommand(int Id, string Name) 
        {
            this.Id = Id;
            this.Name = Name;
        }
    }

    public class UpdateTypeProductPgHandler : IRequestHandler<UpdateTypeProductPgCommand, TypeProductPg>
    {
        private readonly ITypeProductPgService _typeProductPgService;
        private readonly ITypeProductMgService _typeProductMgService;
        private readonly IMapper _mapper;

        public UpdateTypeProductPgHandler(ITypeProductPgService typeProductPgService, ITypeProductMgService typeProductMgService, IMapper mapper)
        {
            _typeProductPgService = typeProductPgService;
            _typeProductMgService = typeProductMgService;
            _mapper = mapper;
        }

        public async Task<TypeProductPg> Handle(UpdateTypeProductPgCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingEntity = await _typeProductPgService.GetById(s => s.Id.Equals(request.Id), s => s.Include(s => s.ProductPg).Include(s => s.InformationTypeProductPg));
                if (existingEntity == null)
                {
                    return null;
                }
                var mapData = _mapper.Map(request, existingEntity);
                await _typeProductPgService.Update(mapData);
                await _typeProductPgService.SubmitSaveAsync();

                // update mongo
                var findMongo = await _typeProductMgService.GetById(existingEntity.Id);
                if (findMongo != null)
                {
                    var objectMg = new TypeProductMg()
                    {
                        Id = findMongo.Id,
                        TypeProductPgId = findMongo.TypeProductPgId,
                        Name = mapData.Name,
                    };

                    var updateMongo = await _typeProductMgService.Update(existingEntity.Id, objectMg);
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
