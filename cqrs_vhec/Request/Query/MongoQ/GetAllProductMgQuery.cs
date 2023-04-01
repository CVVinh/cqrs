using cqrs_vhec.Module.Mongo.EntitiesMg;
using cqrs_vhec.Service.Mongo;
using MediatR;

namespace cqrs_vhec.Request.Query.MongoQ
{
    public class GetAllProductMgQuery : IRequest<List<ProductMg>>
    {
    }

    public class GetAllTypeUnitHandlerMg : IRequestHandler<GetAllProductMgQuery, List<ProductMg>>
    {
        private readonly IProductMgService _productMgService;
        public GetAllTypeUnitHandlerMg(IProductMgService productMgService)
        {
            _productMgService = productMgService;
        }

        public async Task<List<ProductMg>> Handle(GetAllProductMgQuery request, CancellationToken cancellationToken)
        {
            return await _productMgService.GetAll();
        }
    }

}
