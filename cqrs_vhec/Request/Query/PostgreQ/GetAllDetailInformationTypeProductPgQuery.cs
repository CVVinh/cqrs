using AutoMapper;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Service.Postgre;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrs_vhec.Request.Query.PostgreQ
{
    public class GetAllDetailInformationTypeProductPgQuery : IRequest<IEnumerable<DetailInformationTypeProductPg>>
    {
    }

    public class GetAllDetailInformationTypeProductPgHandler : IRequestHandler<GetAllDetailInformationTypeProductPgQuery, IEnumerable<DetailInformationTypeProductPg>>
    {
        private readonly IDetailInformationTypeProductPgService _detailInformationTypeProductPgService;
        private readonly IMapper _mapper;

        public GetAllDetailInformationTypeProductPgHandler(IDetailInformationTypeProductPgService detailInformationTypeProductPgService, IMapper mapper)
        {
            _detailInformationTypeProductPgService = detailInformationTypeProductPgService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DetailInformationTypeProductPg>> Handle(GetAllDetailInformationTypeProductPgQuery request, CancellationToken cancellationToken)
        {
            return await _detailInformationTypeProductPgService.GetAll(s => s.Include(s => s.ProductPg).Include(s => s.InformationTypeProductPg));
        }
    }

}
