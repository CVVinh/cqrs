using AutoMapper;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Service.Postgre;
using MediatR;

namespace cqrs_vhec.Request.Command.PostgreCM
{
    public class CreateTypeProductPgCommand : IRequest<TypeProductPg>
    {
        public string Name { get; set; }
       
        public CreateTypeProductPgCommand()
        {
        }

        public CreateTypeProductPgCommand(string Name)
        {
            this.Name = Name;
        }
    }

    public class CreateTypeProductPgHandler : IRequestHandler<CreateTypeProductPgCommand, TypeProductPg>
    {
        private readonly ITypeProductPgService _typeProductPgService;
        private readonly IMapper _mapper;

        public CreateTypeProductPgHandler(ITypeProductPgService typeProductPgService, IMapper mapper)
        {
            _typeProductPgService = typeProductPgService;
            _mapper = mapper;
        }

        public async Task<TypeProductPg> Handle(CreateTypeProductPgCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mapDataPg = _mapper.Map<TypeProductPg>(request);
                var result = await _typeProductPgService.Insert(mapDataPg);

                return mapDataPg;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
