using AutoMapper;
using cqrs_vhec.Module.Mongo.EntitiesMg;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Request.DTOs;
using cqrs_vhec.Service.Mongo;
using cqrs_vhec.Service.Postgre;
using MediatR;
using System.Xml.Linq;

namespace cqrs_vhec.Request.Command.PostgreCM
{
    public class CreateTypeProductPgCommand : IRequest<BaseResponse<TypeProductPg>>
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

    public class CreateTypeProductPgHandler : IRequestHandler<CreateTypeProductPgCommand, BaseResponse<TypeProductPg>>
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

        public async Task<BaseResponse<TypeProductPg>> Handle(CreateTypeProductPgCommand request, CancellationToken cancellationToken)
        {
            var data = new TypeProductPg();
            try
            {
                var mapDataPg = _mapper.Map<TypeProductPg>(request);
                var result = await _typeProductPgService.Insert(mapDataPg);
                await _typeProductPgService.SubmitSaveAsync();

                if (result != null)
                {
                    //var arrProduct = new List<ProductMg>();
                    //foreach(var item in result.ProductPg)
                    //{
                    //    var objItem = new ProductMg()
                    //    {
                    //        ProductPgId = item.Id,
                    //        Name = item.Name,
                    //        Description = item.Description,
                    //        Quantity = item.Quantity,
                    //        Price = item.Price,
                    //    };
                    //    arrProduct.Add(objItem);
                    //}

                    //var arrInfoTypeProduct = new List<InformationTypeProductMg>();
                    //foreach (var item in result.InformationTypeProductPg)
                    //{
                    //    var objItem = new InformationTypeProductMg()
                    //    {
                    //        InformationTypeProductPgId = item.Id,
                    //        InformationProductMgId = item.InformationProductPgId,
                    //        TypeProductMgId = item.TypeProductPgId,
                    //    };
                    //    arrInfoTypeProduct.Add(objItem);
                    //}

                    var objectMg = new TypeProductMg()
                    {
                        TypeProductPgId = result.Id,
                        Name = result.Name,
                        //ProductMg = arrProduct,
                        //InformationTypeProductMg = arrInfoTypeProduct,
                    };
                    await _typeProductMgService.Create(objectMg);
                }
               
                return new BaseResponse<TypeProductPg>(true, "Object created successfully!", mapDataPg);
            }
            catch (Exception ex)
            {
                return new BaseResponse<TypeProductPg>(false, "Object created failt!", data);
            }
        }
    }
}
