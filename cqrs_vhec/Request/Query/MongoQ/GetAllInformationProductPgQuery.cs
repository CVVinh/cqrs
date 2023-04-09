using cqrs_vhec.Module.Mongo.EntitiesMg;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Request.DTOs;
using cqrs_vhec.Service.Mongo;
using MediatR;

namespace cqrs_vhec.Request.Query.MongoQ
{
    public class GetAllInformationProductMgQuery : IRequest<BaseResponse<List<InformationProductMg>>>
    {
    }

    public class GetAllInformationProductPgHandler : IRequestHandler<GetAllInformationProductMgQuery, BaseResponse<List<InformationProductMg>>>
    {
        private readonly IInformationProductMgService _informationProductMgService;
        public GetAllInformationProductPgHandler(IInformationProductMgService informationProductMgService)
        {
            _informationProductMgService = informationProductMgService;
        }

        public async Task<BaseResponse<List<InformationProductMg>>> Handle(GetAllInformationProductMgQuery request, CancellationToken cancellationToken)
        {
            return new BaseResponse<List<InformationProductMg>>(true, "Get all data successfully!", await _informationProductMgService.GetAll());
        }
    }

}
