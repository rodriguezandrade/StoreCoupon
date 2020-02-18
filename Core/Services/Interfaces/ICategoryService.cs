
using Repository.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IQueryable<GeneralCategory>> GetAll();
        GeneralCategory Save(GeneralCategory category);
        Task<GeneralCategory> DeleteById(Guid Id);
        Task<GeneralCategory> Update(GeneralCategory model);
        Task<GeneralCategory> GetById(Guid id);
        Task<IQueryable> GetCategories();
    }
}
