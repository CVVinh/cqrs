using AutoMapper;
using cqrs_vhec.Module.Mongo;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Request.Command.PostgreCM;
using cqrs_vhec.Request.DTOs;
using cqrs_vhec.Request.Query;

namespace cqrs_vhec.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // ProductPg
            CreateMap<CreateProductPgCommand, ProductPg>().ReverseMap();
            CreateMap<UpdateProductPgCommand, ProductPg>().ReverseMap();
            CreateMap<GetById<ProductPg>, ProductPg>().ReverseMap();
            CreateMap<DeleteProductPgCommand, ProductPg>().ReverseMap();

            // TypeProductPg
            CreateMap<CreateTypeProductPgCommand, TypeProductPg>().ReverseMap();
            CreateMap<UpdateTypeProductPgCommand, TypeProductPg>().ReverseMap();
            CreateMap<GetById<TypeProductPg>, TypeProductPg>().ReverseMap();
            CreateMap<DeleteTypeProductPgCommand, TypeProductPg>().ReverseMap();

            // InformationProductPg
            CreateMap<CreateInformationProductPgCommand, InformationProductPg>().ReverseMap();
            CreateMap<UpdateInformationProductPgCommand, InformationProductPg>().ReverseMap();
            CreateMap<GetById<InformationProductPg>, InformationProductPg>().ReverseMap();
            CreateMap<DeleteInformationProductPgCommand, InformationProductPg>().ReverseMap();

            // InformationTypeProductPg
            CreateMap<CreateInformationTypeProductPgCommand, InformationTypeProductPg>().ReverseMap();
            CreateMap<CreateInformationTypeProductPgDTO, InformationTypeProductPg>().ReverseMap();

            // DetailInformationTypeProductPg
            CreateMap<CreateDetailInformationTypeProductPgDTO, DetailInformationTypeProductPg>().ReverseMap();

        }
    }
}
