using Repository.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        Task<IQueryable<Category>> GetAll();
        Category Save(Category model);
        Task<Category> DeleteById(Guid Id);
        Task<Category> Modify(Category model);
        Task<Category> GetById(Guid id);
        Task<IQueryable> GetCategories();
    }
}
