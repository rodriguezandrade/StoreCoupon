using AutoMapper;
using Repository.Models;
using Repository.Models.Dtos;

namespace Core.Profiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<SubCategoryDto, SubCategory>().ReverseMap();
            CreateMap<StoreDto, Store>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<Coupon, CouponDto>().ReverseMap();
            CreateMap<StoreCategoy, StoreCategoryDto>().ReverseMap();
            CreateMap<GeneralCategoryDto, GeneralCategory>().ReverseMap();
            CreateMap<ProductDetail, ProductDetailDto>().ReverseMap();
            CreateMap<SubCategory, SubCategoryDto>()
                .ForMember(s=>s.CategoryName, c=>c
                    .MapFrom(cat=>cat.Category.Name));

            CreateMap<Coupon, CouponDto>()
                .ForMember(d => d.ProductName, src=>src
                    .MapFrom(s=>s.ProductDetail.Product.Name));

            //CreateMap<Store, StoreDto>()
            //    .ForMember(d => d.SubCategoryName, src => src
            //        .MapFrom(s => s.SubCategory.Name))
            //    .ForMember(d => d.User, src => src
            //        .MapFrom(s => $"{s.User.FirstName} {s.User.LastName}"));

            CreateMap<StoreCategoryDetail, StoreCategoryDetailDto>().ReverseMap();

            CreateMap<StoreCategoryDetail, StoreCategoryDetailDto>()
                .ForMember(d => d.Store, src => src
                    .MapFrom(s => s.Store.Name))
                .ForMember(d => d.Category, src => src
                    .MapFrom(s => s.StoreCategory.Name));

            CreateMap<ProductDetail, ProductDetailDto>()
                .ForMember(d => d.Product, src => src
                    .MapFrom(s => s.Product.Name))
                .ForMember(d => d.IdStoreCategory,src => src
                    .MapFrom(s => s.StoreCategoryDetail.StoreCategory != null ? s.StoreCategoryDetail.StoreCategory.Name : null));
        }
    }
}