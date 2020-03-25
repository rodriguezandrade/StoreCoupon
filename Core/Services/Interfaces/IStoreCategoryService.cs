using Repository.Models.Dtos;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IStoreCategoryService
    {
        Task<IQueryable<StoreCategoryDto>> GetAll();
        Task<IQueryable<StoreCategoryDetails>> GetStoresCategories();
        void Save(StoreCategoryDto category);
        Task<StoreCategoryDto> DeleteById(Guid Id);
        Task<StoreCategoryDto> Update(StoreCategoryDto owner);
        Task<StoreCategoryDto> GetById(Guid id);
    }
}
