﻿using AutoMapper;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Request.DTOs;
using cqrs_vhec.Service.Postgre;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrs_vhec.Request.Query.PostgreQ
{
    public class GetAllProductPgQuery : IRequest<BaseResponse<IEnumerable<ProductPg>>>
    {
    }

    public class GetAllProductPgHandler : IRequestHandler<GetAllProductPgQuery, BaseResponse<IEnumerable<ProductPg>>>
    {
        private readonly IProductPgService _productPgService;
        private readonly IMapper _mapper;

        public GetAllProductPgHandler(IProductPgService productPgService, IMapper mapper)
        {
            _productPgService = productPgService;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<ProductPg>>> Handle(GetAllProductPgQuery request, CancellationToken cancellationToken)
        {
            var data = await _productPgService.GetAll(s => s.Include(s => s.ProductImgPg).Include(s => s.TypeProductPg).Include(s => s.DetailInformationTypeProductPg));
            if (data == null)
            {
                data = new List<ProductPg>();
            }
            return new BaseResponse<IEnumerable<ProductPg>>(true, "Get all data successfully!", data);
        }
    }

}
