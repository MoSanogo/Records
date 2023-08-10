using AutoMapper;
using Records.Data.Dtos;
using Records.Data.Entities;

namespace Records.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap< Cat, CatDto>().ReverseMap();
            CreateMap< CatAddDto, Cat>();
            CreateMap< CatUpdateDto, Cat>();
        }


    }
}