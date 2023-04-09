using AutoMapper;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Request.DTOs;
using cqrs_vhec.Service.Postgre;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrs_vhec.Request.Query.PostgreQ
{
    public class GetByIdTypeProductPgQuery : IRequestHandler<GetById<TypeProductPg>, BaseResponse<TypeProductPg>>
    {
        private readonly ITypeProductPgService _typeProductPgService;
        private readonly IMapper _mapper;

        public GetByIdTypeProductPgQuery(ITypeProductPgService typeProductPgService, IMapper mapper)
        {
            _typeProductPgService = typeProductPgService;
            _mapper = mapper;
        }

        public async Task<BaseResponse<TypeProductPg>> Handle(GetById<TypeProductPg> request, CancellationToken cancellationToken)
        {
            var data = await _typeProductPgService.GetById(s => s.Id.Equals(request.Id), s => s.Include(s => s.ProductPg).Include(s => s.InformationTypeProductPg));
            if (data == null)
            {
                data = new TypeProductPg();
            }
            return new BaseResponse<TypeProductPg>(true, "Get all data successfully!", data);
        }
    }

}
