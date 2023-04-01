using AutoMapper;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Request.Query;
using cqrs_vhec.Service.Postgre;
using MediatR;

namespace cqrs_vhec.Request.Command.PostgreCM
{
    public class UpdateTypeProductPgCommand : IRequest<TypeProductPg>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public UpdateTypeProductPgCommand()
        {
        }

        public UpdateTypeProductPgCommand(int Id, string Name) 
        {
            this.Id = Id;
            this.Name = Name;
        }
    }

    public class UpdateTypeProductPgHandler : IRequestHandler<UpdateTypeProductPgCommand, TypeProductPg>
    {
        private readonly ITypeProductPgService _typeProductPgService;
        private readonly IMapper _mapper;

        public UpdateTypeProductPgHandler(ITypeProductPgService typeProductPgService, IMapper mapper)
        {
            _typeProductPgService = typeProductPgService;
            _mapper = mapper;
        }

        public async Task<TypeProductPg> Handle(UpdateTypeProductPgCommand request, CancellationToken cancellationToken)
        {
            var existingEntity = await _typeProductPgService.GetById(s => s.Id.Equals(request.Id));
            if (existingEntity == null)
            {
                return null;
            }
            var mapData = _mapper.Map(request, existingEntity);
            await _typeProductPgService.Update(mapData);
            return existingEntity;
        }
    }

}
