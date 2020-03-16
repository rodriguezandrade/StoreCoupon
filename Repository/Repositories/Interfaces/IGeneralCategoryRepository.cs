using Repository.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IGeneralCategoryRepository : IRepositoryBase<GeneralCategory>
    {
        Task<IQueryable<GeneralCategory>> GetAll();
        GeneralCategory Save(GeneralCategory model);
        Task<GeneralCategory> DeleteById(Guid Id);
        Task<GeneralCategory> Modify(GeneralCategory model);
        Task<GeneralCategory> GetById(Guid id);
        Task<IQueryable> GetCategories();
    }
}
