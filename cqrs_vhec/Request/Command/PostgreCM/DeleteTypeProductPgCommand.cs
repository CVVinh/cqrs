using AutoMapper;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Request.Query;
using cqrs_vhec.Service.Mongo;
using cqrs_vhec.Service.Postgre;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrs_vhec.Request.Command.PostgreCM
{
    public class DeleteTypeProductPgCommand : IRequest<TypeProductPg>
    {
        public int Id { get; set; }
        public DeleteTypeProductPgCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteTypeProductPgHandler : IRequestHandler<DeleteTypeProductPgCommand, TypeProductPg>
    {
        private readonly ITypeProductPgService _typeProductPgService;
        private readonly ITypeProductMgService _typeProductMgService;
        private readonly IMapper _mapper;

        public DeleteTypeProductPgHandler(ITypeProductPgService typeProductPgService, ITypeProductMgService typeProductMgService, IMapper mapper)
        {
            _typeProductPgService = typeProductPgService;
            _typeProductMgService = typeProductMgService;
            _mapper = mapper;
        }

        public async Task<TypeProductPg> Handle(DeleteTypeProductPgCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingEntity = await _typeProductPgService.GetById(s => s.Id.Equals(request.Id), s => s.Include(s => s.ProductPg).Include(s => s.InformationTypeProductPg));
                if (existingEntity == null)
                {
                    return null;
                }

                await _typeProductPgService.Delete(existingEntity);
                await _typeProductPgService.SubmitSaveAsync();

                // delete mongo
                var findMongo = await _typeProductMgService.GetById(existingEntity.Id);
                var deleteMongo = await _typeProductMgService.Delete(existingEntity.Id);
                if (deleteMongo == true)
                {
                    return existingEntity;
                }
                else
                {
                    return null;
                }
                return existingEntity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}
