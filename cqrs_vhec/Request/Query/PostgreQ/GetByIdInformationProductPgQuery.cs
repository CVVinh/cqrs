using AutoMapper;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Request.DTOs;
using cqrs_vhec.Service.Postgre;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrs_vhec.Request.Query.PostgreQ
{
    public class GetByIdInformationProductPgQuery : IRequestHandler<GetById<InformationProductPg>, BaseResponse<InformationProductPg>>
    {
        private readonly IInformationProductPgService _informationProductPgService;
        private readonly IMapper _mapper;

        public GetByIdInformationProductPgQuery(IInformationProductPgService informationProductPgService, IMapper mapper)
        {
            _informationProductPgService = informationProductPgService;
            _mapper = mapper;
        }

        public async Task<BaseResponse<InformationProductPg>> Handle(GetById<InformationProductPg> request, CancellationToken cancellationToken)
        {
            var data = await _informationProductPgService.GetById(s => s.Id.Equals(request.Id), s => s.Include(s => s.InformationTypeProductPg));
            if (data == null)
            {
                data = new InformationProductPg();
            }
            return new BaseResponse<InformationProductPg>(true, "Get all data successfully!", data);
        }
    }
}
