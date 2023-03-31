using cqrs_vhec.Module.Mongo;
using cqrs_vhec.Service.Mongo;
using MediatR;

namespace cqrs_vhec.Request.Query.MongoQ
{
    public class GetByIdProductMgQuery
    {
    }

    public class GetByIdProductMgQueryMg : IRequest<ProductMg>
    {
        public int IdProject { get; set; }
        public GetByIdProductMgQueryMg(int id)
        {
            IdProject = id;
        }
    }

    public class GetByIdProductMgHandlerMg : IRequestHandler<GetByIdProductMgQueryMg, ProductMg>
    {
        private readonly IProductMgService _productMgService;
        public GetByIdProductMgHandlerMg(IProductMgService productMgService)
        {
            _productMgService = productMgService;
        }

       
        public async Task<ProductMg> Handle(GetByIdProductMgQueryMg request, CancellationToken cancellationToken)
        {
            return await _productMgService.GetById(request.IdProject);
        }
    }



}
