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
            CreateMap<OwnerDto, Owner>().ReverseMap();
            CreateMap<Coupon, CouponDto>().ReverseMap();
            CreateMap<CategoryOfStore, CategoryOfStoreDto>().ReverseMap();
            CreateMap<GeneralCategoryDto, GeneralCategory>().ReverseMap();
            CreateMap<ProductDetail, ProductDetailDto>().ReverseMap();
            CreateMap<SubCategory, SubCategoryDto>()
                .ForMember(s=>s.CategoryName, c=>c
                    .MapFrom(cat=>cat.Category.Name));

            CreateMap<Coupon, CouponDto>()
                .ForMember(d => d.ProductName, src=>src
                    .MapFrom(s=>s.FkProductDetail.FkProduct.Name));

            CreateMap<Store, StoreDto>()
                .ForMember(d => d.SubCategoryName, src => src
                    .MapFrom(s => s.SubCategory.Name))
                .ForMember(d => d.Owner, src => src
                    .MapFrom(s => $"{s.Owner.FirstName} {s.Owner.LastName}"));

            CreateMap<StoreCategory, StoreCategoryDto>().ReverseMap();

            CreateMap<StoreCategory, StoreCategoryDto>()
                .ForMember(d => d.Store, src => src
                    .MapFrom(s => s.FkStore.Name))
                .ForMember(d => d.Category, src => src
                    .MapFrom(s => s.FkCategoryStore.Name));

            CreateMap<ProductDetail, ProductDetailDto>()
                .ForMember(d => d.Product, src => src
                    .MapFrom(s => s.FkProduct.Name))
                .ForMember(d => d.IdStoreCategory,src => src
                    .MapFrom(s => s.FkStoreCategory.FkCategoryStore != null ? s.FkStoreCategory.FkCategoryStore.Name : null));
        }
    }
}