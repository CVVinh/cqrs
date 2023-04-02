using cqrs_vhec.Module.Mongo.EntitiesMg;
using cqrs_vhec.Service.Mongo;
using MediatR;

namespace cqrs_vhec.Request.Query.MongoQ
{
    public class GetByIdInformationProductMgQuery : IRequest<InformationProductMg>
    {
        public int InformationProductPgId { get; set; }
        public GetByIdInformationProductMgQuery(int id)
        {
            InformationProductPgId = id;
        }
    }

    public class GetByIdInformationProductMgHandler : IRequestHandler<GetByIdInformationProductMgQuery, InformationProductMg>
    {
        private readonly IInformationProductMgService _informationProductMgService;
        public GetByIdInformationProductMgHandler(IInformationProductMgService informationProductMgService)
        {
            _informationProductMgService = informationProductMgService;
        }

        public async Task<InformationProductMg> Handle(GetByIdInformationProductMgQuery request, CancellationToken cancellationToken)
        {
            return await _informationProductMgService.GetById(request.InformationProductPgId);
        }
    }

}
