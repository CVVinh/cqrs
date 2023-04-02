using AutoMapper;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Service.Postgre;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrs_vhec.Request.Query.PostgreQ
{
    public class GetByIdDetailInformationTypeProductPgQuery : IRequestHandler<GetById<DetailInformationTypeProductPg>, DetailInformationTypeProductPg>
    {
        private readonly IDetailInformationTypeProductPgService _detailInformationTypeProductPgService;
        private readonly IMapper _mapper;

        public GetByIdDetailInformationTypeProductPgQuery(IDetailInformationTypeProductPgService detailInformationTypeProductPgService, IMapper mapper)
        {
            _detailInformationTypeProductPgService = detailInformationTypeProductPgService;
            _mapper = mapper;
        }

        public async Task<DetailInformationTypeProductPg> Handle(GetById<DetailInformationTypeProductPg> request, CancellationToken cancellationToken)
        {
            return await _detailInformationTypeProductPgService.GetById(s => s.Id.Equals(request.Id), s => s.Include(s => s.ProductPg).Include(s => s.InformationTypeProductPg));
        }
    }

}
