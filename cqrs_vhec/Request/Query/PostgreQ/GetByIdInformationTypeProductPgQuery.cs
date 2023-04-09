using AutoMapper;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Request.DTOs;
using cqrs_vhec.Service.Postgre;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrs_vhec.Request.Query.PostgreQ
{
    public class GetByIdInformationTypeProductPgQuery : IRequestHandler<GetById<InformationTypeProductPg>, BaseResponse<InformationTypeProductPg>>
    {
        private readonly IInformationTypeProductPgService _informationTypeProductPgService;
        private readonly IMapper _mapper;

        public GetByIdInformationTypeProductPgQuery(IInformationTypeProductPgService informationTypeProductPgService, IMapper mapper)
        {
            _informationTypeProductPgService = informationTypeProductPgService;
            _mapper = mapper;
        }

        public async Task<BaseResponse<InformationTypeProductPg>> Handle(GetById<InformationTypeProductPg> request, CancellationToken cancellationToken)
        {
            var data = await _informationTypeProductPgService.GetById(s => s.Id.Equals(request.Id), s => s.Include(s => s.InformationProductPg).Include(s => s.TypeProductPg));
            if (data == null)
            {
                data = new InformationTypeProductPg();
            }
            return new BaseResponse<InformationTypeProductPg>(true, "Get all data successfully!", data);
        }
    }
}
