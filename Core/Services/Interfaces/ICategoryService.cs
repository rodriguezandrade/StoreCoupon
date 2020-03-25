using Repository.Models.Dtos;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IQueryable<CategoryStoreDto>> Get();
        void Save(CategoryStoreDto category);
        Task<CategoryStoreDto> DeleteById(Guid Id);
        Task<CategoryStoreDto> Update(CategoryStoreDto owner);
        Task<CategoryStoreDto> GetById(Guid id); 
    }
}
