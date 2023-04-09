using cqrs_vhec.Module.Mongo.EntitiesMg;
using cqrs_vhec.Request.DTOs;
using cqrs_vhec.Service.Mongo;
using MediatR;

namespace cqrs_vhec.Request.Query.MongoQ
{
    public class GetByIdDetailInformationTypeProductMgQuery : IRequest<BaseResponse<DetailInformationTypeProductMg>>
    {
        public int DetailInformationTypeProductMgId { get; set; }
        public GetByIdDetailInformationTypeProductMgQuery(int id)
        {
            DetailInformationTypeProductMgId = id;
        }
    }

    public class GetByIdDetailInformationTypeProductMgHandler : IRequestHandler<GetByIdDetailInformationTypeProductMgQuery, BaseResponse<DetailInformationTypeProductMg>>
    {
        private readonly IDetailInformationTypeProductMgService _detailInformationTypeProductMgService;
        public GetByIdDetailInformationTypeProductMgHandler(IDetailInformationTypeProductMgService detailInformationTypeProductMgService)
        {
            _detailInformationTypeProductMgService = detailInformationTypeProductMgService;
        }

        public async Task<BaseResponse<DetailInformationTypeProductMg>> Handle(GetByIdDetailInformationTypeProductMgQuery request, CancellationToken cancellationToken)
        {
            return new BaseResponse<DetailInformationTypeProductMg>(true, "Get all data successfully!", await _detailInformationTypeProductMgService.GetById(request.DetailInformationTypeProductMgId));
        }
    }

}
