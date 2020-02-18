using AutoMapper;
using Repository.Models;
using Repository.Models.Dtos;

namespace Core.Profiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<GeneralCategory, CategoryDto>();
            CreateMap<CategoryDto, GeneralCategory>();
            CreateMap<SubCategory, SubCategoryDetails>().ForMember(s=>s.CategoryName, c=>c.MapFrom(cat=>cat.Category.Name));
            CreateMap<StoreDto, Store>().ReverseMap();
        }
    }
}
