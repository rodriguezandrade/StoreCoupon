using AutoMapper;
using Repository.Models;
using Repository.Models.Dtos;

namespace Core.Profiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<SubCategory, SubCategoryDto>();
            CreateMap<StoreDto, Store>().ReverseMap();
        }
    }
}
