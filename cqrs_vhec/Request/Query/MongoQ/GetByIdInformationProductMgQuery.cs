using cqrs_vhec.Module.Mongo.EntitiesMg;
using cqrs_vhec.Request.DTOs;
using cqrs_vhec.Service.Mongo;
using MediatR;

namespace cqrs_vhec.Request.Query.MongoQ
{
    public class GetByIdInformationProductMgQuery : IRequest<BaseResponse<InformationProductMg>>
    {
        public int InformationProductPgId { get; set; }
        public GetByIdInformationProductMgQuery(int id)
        {
            InformationProductPgId = id;
        }
    }

    public class GetByIdInformationProductMgHandler : IRequestHandler<GetByIdInformationProductMgQuery, BaseResponse<InformationProductMg>>
    {
        private readonly IInformationProductMgService _informationProductMgService;
        public GetByIdInformationProductMgHandler(IInformationProductMgService informationProductMgService)
        {
            _informationProductMgService = informationProductMgService;
        }

        public async Task<BaseResponse<InformationProductMg>> Handle(GetByIdInformationProductMgQuery request, CancellationToken cancellationToken)
        {
            return new BaseResponse<InformationProductMg>(true, "Get all data successfully!", await _informationProductMgService.GetById(request.InformationProductPgId));
        }
    }

}
