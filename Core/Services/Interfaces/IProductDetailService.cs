using Repository.Models.Dtos;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IProductDetailService
    {
        Task<IQueryable<ProductDetailDto>> Get();
        Task<IQueryable<ProductDetailDto>> GetDetails();
        void Save(ProductDetailDto product);
        Task<ProductDetailDto> DeleteById(Guid Id);
        Task<ProductDetailDto> Update(ProductDetailDto product);
        Task<ProductDetailDto> GetById(Guid id);
    }
}
