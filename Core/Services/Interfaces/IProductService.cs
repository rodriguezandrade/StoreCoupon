using Repository.Models.Dtos;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IProductService
    {
        Task<IQueryable<ProductDto>> Get();
        void Save(ProductDto category);
        Task<ProductDto> DeleteById(Guid Id);
        Task<ProductDto> Update(ProductDto owner);
        Task<ProductDto> GetById(Guid id);
    }
}
