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
            CreateMap<SubCategory, SubCategoryDetails>()
                .ForMember(s=>s.CategoryName, c=>c
                    .MapFrom(cat=>cat.Category.Name));
            CreateMap<SubCategoryDto, SubCategory>().ReverseMap();
            CreateMap<StoreDto, Store>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<OwnerDto, Owner>().ReverseMap();
            CreateMap<Coupon, CouponDto>().ReverseMap();
            CreateMap<CategoryStore, CategoryStoreDto>().ReverseMap();
            CreateMap<Coupon, CouponDetails>()
                .ForMember(d => d.ProductName, src=>src
                    .MapFrom(s=>s.FkProduDetail.FkProduct.Name));
            CreateMap<Store, StoreDetails>()
                .ForMember(d => d.SubCategorName, src => src
                    .MapFrom(s => s.SubCategory.Name))
                .ForMember(d => d.Owner, src => src
                    .MapFrom(s => $"{s.Owner.FirstName} {s.Owner.LastName}"));
            CreateMap<StoreCategory, StoreCategoryDto>().ReverseMap();
            CreateMap<StoreCategory, StoreCategoryDetails>()
                .ForMember(d => d.Store, src => src
                    .MapFrom(s => s.FkStore.Name))
                .ForMember(d => d.Category, src => src
                    .MapFrom(s => s.FkCategoryStore.Name));
            CreateMap<ProductDetail, ProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, ProductDetailDtl>()
                .ForMember(d => d.Product, src => src
                    .MapFrom(s => s.FkProduct.Name))
                .ForMember(d => d.IdStoreCategory,src => src
                    .MapFrom(s => s.FkStoreCategory.FkCategoryStore != null ? s.FkStoreCategory.FkCategoryStore.Name : null));
        }
    }
}