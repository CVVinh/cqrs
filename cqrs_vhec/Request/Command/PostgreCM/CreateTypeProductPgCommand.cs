using AutoMapper;
using cqrs_vhec.Module.Mongo.EntitiesMg;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Service.Mongo;
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
        private readonly ITypeProductMgService _typeProductMgService;
        private readonly IMapper _mapper;

        public CreateTypeProductPgHandler(ITypeProductPgService typeProductPgService, ITypeProductMgService typeProductMgService, IMapper mapper)
        {
            _typeProductPgService = typeProductPgService;
            _typeProductMgService = typeProductMgService;
            _mapper = mapper;
        }

        public async Task<TypeProductPg> Handle(CreateTypeProductPgCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mapDataPg = _mapper.Map<TypeProductPg>(request);
                var result = await _typeProductPgService.Insert(mapDataPg);
                //if(result != null)
                //{
                //    var objectMg = new TypeProductMg()
                //    {
                //        TypeProductPgId = result.Id,
                //        Name = result.Name,
                //    };
                //    await _typeProductMgService.Create(objectMg);
                //}
               
                return mapDataPg;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
