using AutoMapper;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Service.Postgre;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrs_vhec.Request.Query.PostgreQ
{
    public class GetAllInformationProductPgQuery : IRequest<IEnumerable<InformationProductPg>>
    {
    }

    public class GetAllInformationProductPgHandler : IRequestHandler<GetAllInformationProductPgQuery, IEnumerable<InformationProductPg>>
    {
        private readonly IInformationProductPgService _informationProductPgService;
        private readonly IMapper _mapper;

        public GetAllInformationProductPgHandler(IInformationProductPgService informationProductPgService, IMapper mapper)
        {
            _informationProductPgService = informationProductPgService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InformationProductPg>> Handle(GetAllInformationProductPgQuery request, CancellationToken cancellationToken)
        {
            return await _informationProductPgService.GetAll(s => s.Include(s => s.InformationTypeProductPg));
        }
    }
}
