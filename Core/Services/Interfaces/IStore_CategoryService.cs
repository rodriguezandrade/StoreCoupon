using Repository.Models.Dtos;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IStore_CategoryService
    {
        Task<IQueryable<Store_CategoryDto>> GetAll();
        Task<IQueryable<Store_CategoryDetails>> GetStoresCategories();
        void Save(Store_CategoryDto category);
        Task<Store_CategoryDto> DeleteById(Guid Id);
        Task<Store_CategoryDto> Update(Store_CategoryDto owner);
        Task<Store_CategoryDto> GetById(Guid id);
        Task SaveChanges();
    }
}
