using AutoMapper;
using cqrs_vhec.Module.Mongo;
using cqrs_vhec.Module.Postgre;
using cqrs_vhec.Service.Mongo;
using cqrs_vhec.Service.Postgre;
using MediatR;
using System.Xml.Linq;

namespace cqrs_vhec.Request.Command.PostgreCM
{
    public class CreateProductPgCommand : IRequest<ProductPg>
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public CreateProductPgCommand()
        {
        }

        public CreateProductPgCommand(string name, string? description)
        {
            Name = name;
            Description = description;
        }
    }

    public class CreateProductPgHandler : IRequestHandler<CreateProductPgCommand, ProductPg>
    {
        private readonly IProductPgService _productPgService;
        private readonly IProductMgService _productMgService;
        private readonly IMapper _mapper;

        public CreateProductPgHandler(IProductPgService productPgService, IMapper mapper, IProductMgService productMgService)
        {
            _productPgService = productPgService;
            _productMgService = productMgService;
            _mapper = mapper;
        }

        public async Task<ProductPg> Handle(CreateProductPgCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mapDataPg = _mapper.Map<ProductPg>(request);
                var result = await _productPgService.Insert(mapDataPg);

                if(result != null)
                {
                    var mapDataMg = new ProductMg
                    {
                        IdProject = result.Id,
                        Name = result.Name,
                        Description = result.Description,
                    };
                    var resultMg = await _productMgService.Create(mapDataMg);
                    if(resultMg != null)
                    {
                        return mapDataPg;
                    }
                }
                return mapDataPg;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }

}
