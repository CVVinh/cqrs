using cqrs_vhec.Module.Mongo.EntitiesMg;
using cqrs_vhec.Request.DTOs;
using cqrs_vhec.Service.Mongo;
using MediatR;

namespace cqrs_vhec.Request.Query.MongoQ
{
    public class GetAllDetailInformationTypeProductMgQuery : IRequest<BaseResponse<List<DetailInformationTypeProductMg>>>
    {
    }
    public class GetAllDetailInformationTypeProductMgHandler : IRequestHandler<GetAllDetailInformationTypeProductMgQuery, BaseResponse<List<DetailInformationTypeProductMg>>>
    {
        private readonly IDetailInformationTypeProductMgService _detailInformationTypeProductMgService;
        public GetAllDetailInformationTypeProductMgHandler(IDetailInformationTypeProductMgService detailInformationTypeProductMgService)
        {
            _detailInformationTypeProductMgService = detailInformationTypeProductMgService;
        }

        public async Task<BaseResponse<List<DetailInformationTypeProductMg>>> Handle(GetAllDetailInformationTypeProductMgQuery request, CancellationToken cancellationToken)
        {
            return new BaseResponse<List<DetailInformationTypeProductMg>>(true, "Get all data successfully!", await _detailInformationTypeProductMgService.GetAll());
        }
    }

}
