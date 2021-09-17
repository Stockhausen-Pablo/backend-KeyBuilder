using AutoMapper;
using KeyboardComponentCatalog.Models;
using KeyboardComponentCatalog.Models.Dto;

namespace KeyboardComponentCatalog.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Case, CaseDto>();
            CreateMap<CaseDto, Case>();
        }
    }
}