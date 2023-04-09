using cqrs_vhec.Module.Mongo.EntitiesMg;
using cqrs_vhec.Request.DTOs;
using cqrs_vhec.Service.Mongo;
using MediatR;

namespace cqrs_vhec.Request.Query.MongoQ
{
    public class GetAllProductMgQuery : IRequest<BaseResponse<List<ProductMg>>>
    {
    }

    public class GetAllTypeUnitHandlerMg : IRequestHandler<GetAllProductMgQuery, BaseResponse<List<ProductMg>>>
    {
        private readonly IProductMgService _productMgService;
        public GetAllTypeUnitHandlerMg(IProductMgService productMgService)
        {
            _productMgService = productMgService;
        }

        public async Task<BaseResponse<List<ProductMg>>> Handle(GetAllProductMgQuery request, CancellationToken cancellationToken)
        {
            return new BaseResponse<List<ProductMg>>(true, "Get all data successfully!", await _productMgService.GetAll());
        }
    }

}
