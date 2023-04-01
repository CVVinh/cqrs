using AutoMapper;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Request.Query;
using cqrs_vhec.Service.Postgre;
using MediatR;

namespace cqrs_vhec.Request.Command.PostgreCM
{
    public class DeleteTypeProductPgCommand : IRequestHandler<GetById<TypeProductPg>, TypeProductPg>
    {
        private readonly ITypeProductPgService _typeProductPgService;
        private readonly IMapper _mapper;

        public DeleteTypeProductPgCommand(ITypeProductPgService typeProductPgService, IMapper mapper)
        {
            _typeProductPgService = typeProductPgService;
            _mapper = mapper;
        }

        public async Task<TypeProductPg> Handle(GetById<TypeProductPg> request, CancellationToken cancellationToken)
        {
            var existingEntity = await _typeProductPgService.GetById(s => s.Id.Equals(request.Id));
            if (existingEntity == null)
            {
                return null;
            }

            await _typeProductPgService.Delete(existingEntity);
            return existingEntity;
        }
    }

}
