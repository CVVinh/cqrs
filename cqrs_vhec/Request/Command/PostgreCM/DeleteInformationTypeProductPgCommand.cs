using AutoMapper;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Service.Mongo;
using cqrs_vhec.Service.Postgre;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrs_vhec.Request.Command.PostgreCM
{
    public class DeleteInformationTypeProductPgCommand : IRequest<InformationTypeProductPg>
    {
        public int Id { get; set; }
        public DeleteInformationTypeProductPgCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteInformationTypeProductPgHandler : IRequestHandler<DeleteInformationTypeProductPgCommand, InformationTypeProductPg>
    {
        private readonly IInformationTypeProductPgService _informationTypeProductPgService;
        private readonly IInformationTypeProductMgService _informationTypeProductMgService;
        private readonly IMapper _mapper;

        public DeleteInformationTypeProductPgHandler(IInformationTypeProductPgService informationTypeProductPgService, IInformationTypeProductMgService informationTypeProductMgService, IMapper mapper)
        {
            _informationTypeProductPgService = informationTypeProductPgService;
            _informationTypeProductMgService = informationTypeProductMgService;
            _mapper = mapper;
        }

        public async Task<InformationTypeProductPg> Handle(DeleteInformationTypeProductPgCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingEntity = await _informationTypeProductPgService.GetById(s => s.Id.Equals(request.Id), s => s.Include(s => s.InformationProductPg).Include(s => s.TypeProductPg));
                if (existingEntity == null)
                {
                    return null;
                }
                await _informationTypeProductPgService.Delete(existingEntity);

                // delete mongo
                var findMongo = await _informationTypeProductMgService.GetById(existingEntity.Id);
                var deleteMongo = await _informationTypeProductMgService.Delete(existingEntity.Id);
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
