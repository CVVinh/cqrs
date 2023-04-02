using cqrs_vhec.Module.Mongo.EntitiesMg;
using cqrs_vhec.Service.Mongo;
using MediatR;

namespace cqrs_vhec.Request.Query.MongoQ
{
    public class GetAllTypeProductMgQuery : IRequest<List<TypeProductMg>>
    {
    }

    public class GetAllTypeProductMgHandler : IRequestHandler<GetAllTypeProductMgQuery, List<TypeProductMg>>
    {
        private readonly ITypeProductMgService _typeProductMgService;
        public GetAllTypeProductMgHandler(ITypeProductMgService typeProductMgService)
        {
            _typeProductMgService = typeProductMgService;
        }

        public async Task<List<TypeProductMg>> Handle(GetAllTypeProductMgQuery request, CancellationToken cancellationToken)
        {
            return await _typeProductMgService.GetAll();
        }
    }

}
