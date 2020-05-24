using Repository.Models.Dtos;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IQueryable<StoreCategoryDto>> Get();
        void Save(StoreCategoryDto storeCategory);
        Task<StoreCategoryDto> DeleteById(Guid Id);
        Task<StoreCategoryDto> Update(StoreCategoryDto owner);
        Task<StoreCategoryDto> GetById(Guid id); 
    }
}
