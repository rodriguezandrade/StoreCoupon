using System;
using System.Linq;
using System.Threading.Tasks;
using Repository.Models.Dtos;

namespace Core.Services.Interfaces
{
    public interface ISubCategoryService
    {
        Task<IQueryable<SubCategoryDto>> FindAll();
        Task<IQueryable<SubCategoryDto>> GetAll();
        void Save(SubCategoryDto category);
        Task<SubCategoryDto> DeleteById(Guid Id);
        Task<SubCategoryDto> Update(SubCategoryDto subcategory);
        Task<SubCategoryDto> GetById(Guid id);
    }
}
