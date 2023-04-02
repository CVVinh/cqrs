using AutoMapper;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Request.Query;
using cqrs_vhec.Service.Mongo;
using cqrs_vhec.Service.Postgre;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrs_vhec.Request.Command.PostgreCM
{
    public class DeleteProductPgCommand : IRequest<ProductPg>
    {
        public int Id { get; set; }
        public DeleteProductPgCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteProductPgHandler : IRequestHandler<DeleteProductPgCommand, ProductPg>
    {
        private readonly IProductPgService _productPgService;
        private readonly IProductMgService _productMgService;
        private readonly IMapper _mapper;

        public DeleteProductPgHandler(IProductPgService productPgService, IProductMgService productMgService, IMapper mapper)
        {
            _productPgService = productPgService;
            _productMgService = productMgService;
            _mapper = mapper;
        }

        public async Task<ProductPg> Handle(DeleteProductPgCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingEntity = await _productPgService.GetById(s => s.Id.Equals(request.Id), s => s.Include(s => s.ProductImgPg).Include(s => s.TypeProductPg).Include(s => s.DetailInformationTypeProductPg));
                if (existingEntity == null)
                {
                    return null;
                }

                await _productPgService.Delete(existingEntity);

                // delete mongo
                var findMongo = await _productMgService.GetById(existingEntity.Id);
                var deleteMongo = await _productMgService.Delete(existingEntity.Id);
                if(deleteMongo == true)
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
