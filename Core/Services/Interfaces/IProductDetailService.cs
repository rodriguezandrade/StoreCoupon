using Repository.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IProductDetailService
    {
        Task<IQueryable<ProductDetailDto>> GetAll();
        Task<IQueryable<ProductDetailDtl>> GetProducts();
        void Save(ProductDetailDto product);
        Task<ProductDetailDto> DeleteById(Guid Id);
        Task<ProductDetailDto> Update(ProductDetailDto product);
        Task<ProductDetailDto> GetById(Guid id);
    }
}
