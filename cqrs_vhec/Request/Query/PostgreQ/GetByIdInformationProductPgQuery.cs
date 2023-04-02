using AutoMapper;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Service.Postgre;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrs_vhec.Request.Query.PostgreQ
{
    public class GetByIdInformationProductPgQuery : IRequestHandler<GetById<InformationProductPg>, InformationProductPg>
    {
        private readonly IInformationProductPgService _informationProductPgService;
        private readonly IMapper _mapper;

        public GetByIdInformationProductPgQuery(IInformationProductPgService informationProductPgService, IMapper mapper)
        {
            _informationProductPgService = informationProductPgService;
            _mapper = mapper;
        }

        public async Task<InformationProductPg> Handle(GetById<InformationProductPg> request, CancellationToken cancellationToken)
        {
            return await _informationProductPgService.GetById(s => s.Id.Equals(request.Id), s => s.Include(s => s.InformationTypeProductPg));
        }
    }
}
