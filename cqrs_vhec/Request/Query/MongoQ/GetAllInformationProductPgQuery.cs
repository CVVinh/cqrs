using cqrs_vhec.Module.Mongo.EntitiesMg;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Service.Mongo;
using MediatR;

namespace cqrs_vhec.Request.Query.MongoQ
{
    public class GetAllInformationProductMgQuery : IRequest<List<InformationProductMg>>
    {
    }

    public class GetAllInformationProductPgHandler : IRequestHandler<GetAllInformationProductMgQuery, List<InformationProductMg>>
    {
        private readonly IInformationProductMgService _informationProductMgService;
        public GetAllInformationProductPgHandler(IInformationProductMgService informationProductMgService)
        {
            _informationProductMgService = informationProductMgService;
        }

        public async Task<List<InformationProductMg>> Handle(GetAllInformationProductMgQuery request, CancellationToken cancellationToken)
        {
            return await _informationProductMgService.GetAll();
        }
    }

}
