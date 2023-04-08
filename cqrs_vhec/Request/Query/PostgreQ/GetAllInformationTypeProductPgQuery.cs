using AutoMapper;
using cqrs_vhec.Module.Mongo.EntitiesMg;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Service.Postgre;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrs_vhec.Request.Query.PostgreQ
{
    public class GetAllInformationTypeProductPgQuery : IRequest<IEnumerable<InformationTypeProductPg>>
    {
    }

    public class GetAllInformationTypeProductPgHandler : IRequestHandler<GetAllInformationTypeProductPgQuery, IEnumerable<InformationTypeProductPg>>
    {
        private readonly IInformationTypeProductPgService _informationTypeProductPgService;
        private readonly IMapper _mapper;

        public GetAllInformationTypeProductPgHandler(IInformationTypeProductPgService informationTypeProductPgService, IMapper mapper)
        {
            _informationTypeProductPgService = informationTypeProductPgService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InformationTypeProductPg>> Handle(GetAllInformationTypeProductPgQuery request, CancellationToken cancellationToken)
        {
            return await _informationTypeProductPgService.GetAll(s => s.Include(s => s.InformationProductPg).Include(s => s.TypeProductPg));
        }
    }

}
