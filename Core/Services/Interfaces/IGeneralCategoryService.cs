
using Repository.Models;
using Repository.Models.Dtos;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IGeneralCategoryService
    {
        Task<IQueryable<GeneralCategoryDto>> Get();
        void Save(GeneralCategoryDto category);
        Task<GeneralCategoryDto> DeleteById(Guid Id);
        Task<GeneralCategoryDto> Update(GeneralCategoryDto model);
        Task<GeneralCategoryDto> GetById(Guid id);
    }
}
