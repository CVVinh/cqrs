using AutoMapper;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Service.Mongo;
using cqrs_vhec.Service.Postgre;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrs_vhec.Request.Command.PostgreCM
{
    public class DeleteDetailInformationTypeProductPgCommand : IRequest<DetailInformationTypeProductPg>
    {
        public int Id { get; set; }
        public DeleteDetailInformationTypeProductPgCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteDetailInformationTypeProductPgHandler : IRequestHandler<DeleteDetailInformationTypeProductPgCommand, DetailInformationTypeProductPg>
    {
        private readonly IDetailInformationTypeProductPgService _detailInformationTypeProductPgService;
        private readonly IDetailInformationTypeProductMgService _detailInformationTypeProductMgService;
        private readonly IMapper _mapper;

        public DeleteDetailInformationTypeProductPgHandler(IDetailInformationTypeProductPgService detailInformationTypeProductPgService, IDetailInformationTypeProductMgService detailInformationTypeProductMgService, IMapper mapper)
        {
            _detailInformationTypeProductPgService = detailInformationTypeProductPgService;
            _detailInformationTypeProductMgService = detailInformationTypeProductMgService;
            _mapper = mapper;
        }

        public async Task<DetailInformationTypeProductPg> Handle(DeleteDetailInformationTypeProductPgCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingEntity = await _detailInformationTypeProductPgService.GetById(s => s.Id.Equals(request.Id), s => s.Include(s => s.ProductPg).Include(s => s.InformationTypeProductPg));
                if (existingEntity == null)
                {
                    return null;
                }

                await _detailInformationTypeProductPgService.Delete(existingEntity);
                await _detailInformationTypeProductPgService.SubmitSaveAsync();

                // delete mongo
                var findMongo = await _detailInformationTypeProductMgService.GetById(existingEntity.Id);
                var deleteMongo = await _detailInformationTypeProductMgService.Delete(existingEntity.Id);
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
