using AutoMapper;
using cqrs_vhec.Module.Mongo.EntitiesMg;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Request.DTOs;
using cqrs_vhec.Service.Postgre;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrs_vhec.Request.Query.PostgreQ
{
    public class GetAllDetailInformationTypeProductPgQuery : IRequest<BaseResponse<IEnumerable<DetailInformationTypeProductPg>>>
    {
    }

    public class GetAllDetailInformationTypeProductPgHandler : IRequestHandler<GetAllDetailInformationTypeProductPgQuery, BaseResponse<IEnumerable<DetailInformationTypeProductPg>>>
    {
        private readonly IDetailInformationTypeProductPgService _detailInformationTypeProductPgService;
        private readonly IMapper _mapper;

        public GetAllDetailInformationTypeProductPgHandler(IDetailInformationTypeProductPgService detailInformationTypeProductPgService, IMapper mapper)
        {
            _detailInformationTypeProductPgService = detailInformationTypeProductPgService;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<DetailInformationTypeProductPg>>> Handle(GetAllDetailInformationTypeProductPgQuery request, CancellationToken cancellationToken)
        {
            var data = await _detailInformationTypeProductPgService.GetAll(s => s.Include(s => s.ProductPg).Include(s => s.InformationTypeProductPg));
            if (data == null)
            {
                data = new List<DetailInformationTypeProductPg>();
            }
            return new BaseResponse<IEnumerable<DetailInformationTypeProductPg>>(true, "Get all data successfully!", data);
        }
    }

}
