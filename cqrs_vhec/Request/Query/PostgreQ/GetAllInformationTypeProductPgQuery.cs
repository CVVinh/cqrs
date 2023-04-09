using AutoMapper;
using cqrs_vhec.Module.Mongo.EntitiesMg;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Request.DTOs;
using cqrs_vhec.Service.Postgre;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrs_vhec.Request.Query.PostgreQ
{
    public class GetAllInformationTypeProductPgQuery : IRequest<BaseResponse<IEnumerable<InformationTypeProductPg>>>
    {
    }

    public class GetAllInformationTypeProductPgHandler : IRequestHandler<GetAllInformationTypeProductPgQuery, BaseResponse<IEnumerable<InformationTypeProductPg>>>
    {
        private readonly IInformationTypeProductPgService _informationTypeProductPgService;
        private readonly IMapper _mapper;

        public GetAllInformationTypeProductPgHandler(IInformationTypeProductPgService informationTypeProductPgService, IMapper mapper)
        {
            _informationTypeProductPgService = informationTypeProductPgService;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<InformationTypeProductPg>>> Handle(GetAllInformationTypeProductPgQuery request, CancellationToken cancellationToken)
        {
            var data = await _informationTypeProductPgService.GetAll(s => s.Include(s => s.InformationProductPg).Include(s => s.TypeProductPg));
            if (data == null)
            {
                data = new List<InformationTypeProductPg>();
            }
            return new BaseResponse<IEnumerable<InformationTypeProductPg>>(true, "Get all data successfully!", data);
        }
    }

}
