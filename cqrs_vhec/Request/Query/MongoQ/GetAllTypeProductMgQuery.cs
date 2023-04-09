using cqrs_vhec.Module.Mongo.EntitiesMg;
using cqrs_vhec.Request.DTOs;
using cqrs_vhec.Service.Mongo;
using MediatR;

namespace cqrs_vhec.Request.Query.MongoQ
{
    public class GetAllTypeProductMgQuery : IRequest<BaseResponse<List<TypeProductMg>>>
    {
    }

    public class GetAllTypeProductMgHandler : IRequestHandler<GetAllTypeProductMgQuery, BaseResponse<List<TypeProductMg>>>
    {
        private readonly ITypeProductMgService _typeProductMgService;
        public GetAllTypeProductMgHandler(ITypeProductMgService typeProductMgService)
        {
            _typeProductMgService = typeProductMgService;
        }

        public async Task<BaseResponse<List<TypeProductMg>>> Handle(GetAllTypeProductMgQuery request, CancellationToken cancellationToken)
        {
            return new BaseResponse<List<TypeProductMg>>(true, "Get all data successfully!", await _typeProductMgService.GetAll());
        }
    }

}
