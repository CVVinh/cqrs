using AutoMapper;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Request.Query;
using cqrs_vhec.Service.Mongo;
using cqrs_vhec.Service.Postgre;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrs_vhec.Request.Command.PostgreCM
{
    public class DeleteInformationProductPgCommand : IRequest<InformationProductPg>
    {
        public int Id { get; set; }
        public DeleteInformationProductPgCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteInformationProductPgHandler : IRequestHandler<DeleteInformationProductPgCommand, InformationProductPg>
    {
        private readonly IInformationProductPgService _informationProductPgService;
        private readonly IInformationProductMgService _informationProductMgService;
        private readonly IMapper _mapper;

        public DeleteInformationProductPgHandler(IInformationProductPgService informationProductPgService, IInformationProductMgService informationProductMgService, IMapper mapper)
        {
            _informationProductPgService = informationProductPgService;
            _informationProductMgService = informationProductMgService;
            _mapper = mapper;
        }

        public async Task<InformationProductPg> Handle(DeleteInformationProductPgCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingEntity = await _informationProductPgService.GetById(s => s.Id.Equals(request.Id), s => s.Include(s => s.InformationTypeProductPg));
                if (existingEntity == null)
                {
                    return null;
                }
                await _informationProductPgService.Delete(existingEntity);
                await _informationProductPgService.SubmitSaveAsync();

                // delete mongo
                var findMongo = await _informationProductMgService.GetById(existingEntity.Id);
                var deleteMongo = await _informationProductMgService.Delete(existingEntity.Id);
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
