using AutoMapper;
using Repository.Models;
using Repository.Models.Dtos;

namespace Core.Profiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<GeneralCategoryDto, GeneralCategory>().ReverseMap();
            CreateMap<SubCategory, SubCategoryDetails>().ForMember(s=>s.CategoryName, c=>c.MapFrom(cat=>cat.Category.Name));
            CreateMap<SubCategoryDto, SubCategory>();
            CreateMap<StoreDto, Store>().ReverseMap();
            CreateMap<OwnerDto, Owner>().ReverseMap();
            CreateMap<CouponDto, Coupon>().ReverseMap();
            CreateMap<Coupon, CouponDetails>().ForMember(d=>d.ProductName, src=>src.MapFrom(s=>s.FkProd.Name));
        }
    }
}
