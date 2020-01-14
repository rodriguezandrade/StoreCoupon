
using Repository.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IQueryable<Category>> GetAll();
        Category Save(Category category);
        Task<Category> DeleteByName(string name);
        Task<Category> Update(Category model);
        Task<Category> GetById(Guid id);
    }
}
