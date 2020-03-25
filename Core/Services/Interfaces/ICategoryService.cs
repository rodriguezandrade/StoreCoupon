using Repository.Models.Dtos;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IQueryable<CategoryOfStoreDto>> Get();
        void Save(CategoryOfStoreDto category);
        Task<CategoryOfStoreDto> DeleteById(Guid Id);
        Task<CategoryOfStoreDto> Update(CategoryOfStoreDto owner);
        Task<CategoryOfStoreDto> GetById(Guid id); 
    }
}
