using cqrs_vhec.Module.Mongo.EntitiesMg;
using cqrs_vhec.Service.Mongo;
using MediatR;

namespace cqrs_vhec.Request.Query.MongoQ
{
    public class GetAllDetailInformationTypeProductMgQuery : IRequest<List<DetailInformationTypeProductMg>>
    {
    }
    public class GetAllDetailInformationTypeProductMgHandler : IRequestHandler<GetAllDetailInformationTypeProductMgQuery, List<DetailInformationTypeProductMg>>
    {
        private readonly IDetailInformationTypeProductMgService _detailInformationTypeProductMgService;
        public GetAllDetailInformationTypeProductMgHandler(IDetailInformationTypeProductMgService detailInformationTypeProductMgService)
        {
            _detailInformationTypeProductMgService = detailInformationTypeProductMgService;
        }

        public async Task<List<DetailInformationTypeProductMg>> Handle(GetAllDetailInformationTypeProductMgQuery request, CancellationToken cancellationToken)
        {
            return await _detailInformationTypeProductMgService.GetAll();
        }
    }

}
