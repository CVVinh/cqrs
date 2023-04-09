using AutoMapper;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Request.DTOs;
using cqrs_vhec.Service.Postgre;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrs_vhec.Request.Query.PostgreQ
{
    public class GetAllInformationProductPgQuery : IRequest<BaseResponse<IEnumerable<InformationProductPg>>>
    {
    }

    public class GetAllInformationProductPgHandler : IRequestHandler<GetAllInformationProductPgQuery, BaseResponse<IEnumerable<InformationProductPg>>>
    {
        private readonly IInformationProductPgService _informationProductPgService;
        private readonly IMapper _mapper;

        public GetAllInformationProductPgHandler(IInformationProductPgService informationProductPgService, IMapper mapper)
        {
            _informationProductPgService = informationProductPgService;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<InformationProductPg>>> Handle(GetAllInformationProductPgQuery request, CancellationToken cancellationToken)
        {
            var data = await _informationProductPgService.GetAll(s => s.Include(s => s.InformationTypeProductPg));
            if (data == null)
            {
                data = new List<InformationProductPg>();
            }
            return new BaseResponse<IEnumerable<InformationProductPg>>(true, "Get all data successfully!", data);
        }
    }
}
