using AutoMapper;
using cqrs_vhec.Module.Mongo;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Request.Command.PostgreCM;
using cqrs_vhec.Request.Query;

namespace cqrs_vhec.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // ProductPg
            CreateMap<CreateProductPgCommand, ProductPg>().ReverseMap();

            // TypeProductPg
            CreateMap<CreateTypeProductPgCommand, TypeProductPg>().ReverseMap();
            CreateMap<UpdateTypeProductPgCommand, TypeProductPg>().ReverseMap();
            CreateMap<GetById<TypeProductPg>, TypeProductPg>().ReverseMap();

            //CreateMap<UpdateTypeUnitCommand, TypeUnit>().ReverseMap();
            //CreateMap<DeleteTypeUnitCommand, TypeUnit>().ReverseMap();
        }
    }
}
