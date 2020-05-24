using Repository.Models.Dtos;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IStoreCategoryService
    {
        Task<IQueryable<StoreCategoryDetailDto>> Get();
        Task<IQueryable<StoreCategoryDetailDto>> GetDetails();
        void Save(StoreCategoryDetailDto categoryDetail);
        Task<StoreCategoryDetailDto> DeleteById(Guid Id);
        Task<StoreCategoryDetailDto> Update(StoreCategoryDetailDto owner);
        Task<StoreCategoryDetailDto> GetById(Guid id);
    }
}
