using cqrs_vhec.Module.Mongo.EntitiesMg;
using cqrs_vhec.Service.Mongo;
using MediatR;

namespace cqrs_vhec.Request.Query.MongoQ
{
    public class GetByIdTypeProductMgQuery : IRequest<TypeProductMg>
    {
        public int TypeProductPgId { get; set; }
        public GetByIdTypeProductMgQuery(int id)
        {
            TypeProductPgId = id;
        }
    }

    public class GetByIdTypeProductMgHandler : IRequestHandler<GetByIdTypeProductMgQuery, TypeProductMg>
    {
        private readonly ITypeProductMgService _typeProductMgService;
        public GetByIdTypeProductMgHandler(ITypeProductMgService typeProductMgService)
        {
            _typeProductMgService = typeProductMgService;
        }

        public async Task<TypeProductMg> Handle(GetByIdTypeProductMgQuery request, CancellationToken cancellationToken)
        {
            return await _typeProductMgService.GetById(request.TypeProductPgId);
        }
    }

}
