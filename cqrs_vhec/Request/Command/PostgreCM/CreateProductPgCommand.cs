using AutoMapper;
using cqrs_vhec.Module.Mongo;
using cqrs_vhec.Module.Postgre.Entities;
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
        public int Quantity { get; set; }
        public int Price { get; set; }

        public int TypeProductPgId { get; set; }

        public CreateProductPgCommand()
        {
        }

        public CreateProductPgCommand(string Name, string? Description, int Quantity, int Price, int TypeProductPgId)
        {
            this.Name = Name;
            this.Description = Description;
            this.Quantity = Quantity;
            this.Price = Price;
            this.TypeProductPgId = TypeProductPgId;
        }
    }

    public class CreateProductPgHandler : IRequestHandler<CreateProductPgCommand, ProductPg>
    {
        private readonly IProductPgService _productPgService;
        private readonly IMapper _mapper;

        public CreateProductPgHandler(IProductPgService productPgService, IMapper mapper)
        {
            _productPgService = productPgService;
            _mapper = mapper;
        }

        public async Task<ProductPg> Handle(CreateProductPgCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mapDataPg = _mapper.Map<ProductPg>(request);
                var result = await _productPgService.Insert(mapDataPg);

                return mapDataPg;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }

}
