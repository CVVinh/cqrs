using cqrs_vhec.Module.Mongo.EntitiesMg;
using cqrs_vhec.Request.DTOs;
using cqrs_vhec.Service.Mongo;
using MediatR;

namespace cqrs_vhec.Request.Query.MongoQ
{
    public class GetByIdProductMgQueryMg : IRequest<BaseResponse<ProductMg>>
    {
        public int IdProject { get; set; }
        public GetByIdProductMgQueryMg(int id)
        {
            IdProject = id;
        }
    }

    public class GetByIdProductMgHandlerMg : IRequestHandler<GetByIdProductMgQueryMg, BaseResponse<ProductMg>>
    {
        private readonly IProductMgService _productMgService;
        public GetByIdProductMgHandlerMg(IProductMgService productMgService)
        {
            _productMgService = productMgService;
        }

       
        public async Task<BaseResponse<ProductMg>> Handle(GetByIdProductMgQueryMg request, CancellationToken cancellationToken)
        {
            return new BaseResponse<ProductMg>(true, "Get all data successfully!", await _productMgService.GetById(request.IdProject));
        }
    }



}
