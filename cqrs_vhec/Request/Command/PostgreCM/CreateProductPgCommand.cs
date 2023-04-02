using AutoMapper;
using cqrs_vhec.Helper;
using cqrs_vhec.Module.Mongo.EntitiesMg;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Request.DTOs;
using cqrs_vhec.Service.Mongo;
using cqrs_vhec.Service.Postgre;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace cqrs_vhec.Request.Command.PostgreCM
{
    public class CreateProductPgCommand : CreateProductPgDTO, IRequest<ProductPg>
    {
        public string FileSaveLink { get; set; }
        public string LinkServer { get; set; }

        public CreateProductPgCommand() : base()
        {
        }

        public CreateProductPgCommand(CreateProductPgDTO createProductPgDTO, string fileSaveLink, string linkServer) : base(createProductPgDTO.Name, createProductPgDTO.Description, createProductPgDTO.Quantity, createProductPgDTO.Price, createProductPgDTO.TypeProductPgId, createProductPgDTO.ProductImage)
        {
            this.FileSaveLink = fileSaveLink;
            this.LinkServer = linkServer;
        }

        public CreateProductPgCommand(string Name, string? Description, int Quantity, int Price, int TypeProductPgId, ICollection<IFormFile>? ProductImage, ICollection<CreateDetailInformationTypeProductPgDTO>? DetailInformationTypeProductPg, string FileSaveLink, string LinkServer) 
            : base(Name, Description, Quantity, Price, TypeProductPgId, ProductImage)
        {
            this.FileSaveLink = FileSaveLink;
            this.LinkServer = LinkServer;
        }
    }

    public class CreateProductPgHandler : IRequestHandler<CreateProductPgCommand, ProductPg>
    {
        private readonly IProductPgService _productPgService;
        private readonly IProductMgService _productMgService;
        private readonly IMapper _mapper;

        public CreateProductPgHandler(IProductPgService productPgService, IProductMgService productMgService, IMapper mapper)
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
                if (request.ProductImage != null)
                {
                    foreach (var item in request.ProductImage)
                    {
                        mapDataPg.ProductImgPg.Add(new ProductImgPg()
                        {
                            ImgPath = request.LinkServer + FilesHelper.UploadFileAndReturnPath(item, request.FileSaveLink, "/ProductPicture/")
                        });
                    }
                }
                else
                {
                    mapDataPg.ProductImgPg = new List<ProductImgPg>();
                }
                var result = await _productPgService.Insert(mapDataPg);
                if(request != null)
                {
                    var addMongo = await _productPgService.GetById(s => s.Id.Equals(mapDataPg.Id), s => s.Include(s => s.ProductImgPg).Include(s => s.TypeProductPg).Include(s => s.DetailInformationTypeProductPg));

                    var arrProductImgMg = new List<ProductImgMg>();
                    foreach(var item in addMongo.ProductImgPg)
                    {
                        var objImg = new ProductImgMg()
                        {
                            ProductImgPgId = item.Id,
                            ImgPath = item.ImgPath,
                            ProductMgId = item.ProductPgId,
                        };
                        arrProductImgMg.Add(objImg);
                    }
                    var arrProductDetailMg = new List<DetailInformationTypeProductMg>();
                    foreach (var item in addMongo.DetailInformationTypeProductPg)
                    {
                        var objDetail = new DetailInformationTypeProductMg()
                        {
                            DetailInformationTypeProductPgId = item.Id,
                            InformationTypeProductMgId = item.InformationTypeProductPgId,
                            ProductMgId = item.ProductPgId,
                            Content = item.Content,
                        };
                        arrProductDetailMg.Add(objDetail);
                    }

                    var objectMg = new ProductMg()
                    {
                        ProductPgId = result.Id,
                        Name = addMongo.Name,
                        Description = addMongo.Description,
                        Quantity = addMongo.Quantity ,
                        Price = addMongo.Price ,
                        TypeProductId = addMongo.TypeProductPgId,
                        ProductImgMg = arrProductImgMg,
                        DetailInformationTypeProductMg = arrProductDetailMg,
                    };
                    await _productMgService.Create(objectMg);
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
