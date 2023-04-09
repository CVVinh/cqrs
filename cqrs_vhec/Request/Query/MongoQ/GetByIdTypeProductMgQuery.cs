using cqrs_vhec.Module.Mongo.EntitiesMg;
using cqrs_vhec.Request.DTOs;
using cqrs_vhec.Service.Mongo;
using MediatR;

namespace cqrs_vhec.Request.Query.MongoQ
{
    public class GetByIdTypeProductMgQuery : IRequest<BaseResponse<TypeProductMg>>
    {
        public int TypeProductPgId { get; set; }
        public GetByIdTypeProductMgQuery(int id)
        {
            TypeProductPgId = id;
        }
    }

    public class GetByIdTypeProductMgHandler : IRequestHandler<GetByIdTypeProductMgQuery, BaseResponse<TypeProductMg>>
    {
        private readonly ITypeProductMgService _typeProductMgService;
        public GetByIdTypeProductMgHandler(ITypeProductMgService typeProductMgService)
        {
            _typeProductMgService = typeProductMgService;
        }

        public async Task<BaseResponse<TypeProductMg>> Handle(GetByIdTypeProductMgQuery request, CancellationToken cancellationToken)
        {
            return new BaseResponse<TypeProductMg>(true, "Get all data successfully!", await _typeProductMgService.GetById(request.TypeProductPgId));
        }
    }

}
