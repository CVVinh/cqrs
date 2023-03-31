using AutoMapper;
using cqrs_vhec.Module.Mongo;
using cqrs_vhec.Module.Postgre;
using cqrs_vhec.Request.Command.PostgreCM;

namespace cqrs_vhec.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateProductPgCommand, ProductPg>().ReverseMap();

            //CreateMap<UpdateTypeUnitCommand, TypeUnit>().ReverseMap();
            //CreateMap<DeleteTypeUnitCommand, TypeUnit>().ReverseMap();
        }
    }
}
