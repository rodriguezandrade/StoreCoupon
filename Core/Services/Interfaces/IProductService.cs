using Repository.Models;
using Repository.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IProductService
    {
        Task<IQueryable<ProductDto>> GetAll();
        void Save(ProductDto category);
        Task<ProductDto> DeleteById(Guid Id);
        Task<ProductDto> Update(ProductDto owner);
        Task<ProductDto> GetById(Guid id);
    }
}
