using AutoMapper;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Request.DTOs;
using cqrs_vhec.Service.Postgre;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrs_vhec.Request.Query.PostgreQ
{
    public class GetByIdProductPgQuery : IRequestHandler<GetById<ProductPg>, BaseResponse<ProductPg>>
    {
        private readonly IProductPgService _productPgService;
        private readonly IMapper _mapper;

        public GetByIdProductPgQuery(IProductPgService productPgService, IMapper mapper)
        {
            _productPgService = productPgService;
            _mapper = mapper;
        }

        public async Task<BaseResponse<ProductPg>> Handle(GetById<ProductPg> request, CancellationToken cancellationToken)
        {
            var data = await _productPgService.GetById(s => s.Id.Equals(request.Id), s => s.Include(s => s.ProductImgPg).Include(s => s.TypeProductPg).Include(s => s.DetailInformationTypeProductPg));
            if (data == null)
            {
                data = new ProductPg();
            }
            return new BaseResponse<ProductPg>(true, "Get all data successfully!", data);
        }
    }
}
