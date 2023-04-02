using AutoMapper;
using cqrs_vhec.Helper;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Request.DTOs;
using cqrs_vhec.Service.Mongo;
using cqrs_vhec.Service.Postgre;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace cqrs_vhec.Request.Command.PostgreCM
{
    public class UpdateProductPgCommand : UpdateProductPgDTO, IRequest<ProductPg>
    {
        public string FileSaveLink { get; set; }
        public string LinkServer { get; set; }

        public UpdateProductPgCommand() : base()
        {
        }

        public UpdateProductPgCommand(int id, CreateProductPgDTO createProductPgDTO, string fileSaveLink, string linkServer) : base(id, createProductPgDTO)
        {
            this.FileSaveLink = fileSaveLink;
            this.LinkServer = linkServer;
        }
    }

    public class UpdateProductPgHandler : IRequestHandler<UpdateProductPgCommand, ProductPg>
    {
        private readonly IProductPgService _productPgService;
        private readonly IProductImgPgService _productImgPgService;
        private readonly IProductMgService _productMgService;
        private readonly IMapper _mapper;

        public UpdateProductPgHandler(IProductPgService productPgService, IProductImgPgService productImgPgService, IProductMgService productMgService, IMapper mapper)
        {
            _productPgService = productPgService;
            _productImgPgService = productImgPgService;
            _productMgService = productMgService;
            _mapper = mapper;
        }

        public async Task<ProductPg> Handle(UpdateProductPgCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingEntity = await _productPgService.GetById(s => s.Id.Equals(request.Id), s => s.Include(s => s.ProductImgPg).Include(s => s.TypeProductPg).Include(s => s.DetailInformationTypeProductPg));
                if (existingEntity == null)
                {
                    return null;
                }
                var mapDataPg = _mapper.Map(request, existingEntity);
                foreach (var img in mapDataPg.ProductImgPg)
                {
                    var fileName = img.ImgPath?.Replace($"{request.LinkServer}/ProductPicture/", "");
                    string filePath = System.IO.Path.Combine(request.FileSaveLink, "ProductPicture", fileName ?? "");
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                        await _productImgPgService.Delete(img);
                    }
                }
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
                await _productPgService.Update(mapDataPg);

                return mapDataPg;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }


}
