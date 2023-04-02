using AutoMapper;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Service.Postgre;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrs_vhec.Request.Query.PostgreQ
{
    public class GetAllTypeProductPgQuery : IRequest<IEnumerable<TypeProductPg>>
    {
    }

    public class GetAllTypeProductPgHandler : IRequestHandler<GetAllTypeProductPgQuery, IEnumerable<TypeProductPg>>
    {
        private readonly ITypeProductPgService _typeProductPgService;
        private readonly IMapper _mapper;

        public GetAllTypeProductPgHandler(ITypeProductPgService typeProductPgService, IMapper mapper)
        {
            _typeProductPgService = typeProductPgService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TypeProductPg>> Handle(GetAllTypeProductPgQuery request, CancellationToken cancellationToken)
        {
            return await _typeProductPgService.GetAll(s => s.Include(s => s.ProductPg).Include(s => s.InformationTypeProductPg));
        }
    }

}
