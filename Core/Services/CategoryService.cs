using Core.Services.Interfaces;
using Repository.Models;
using Repository.Repositories.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IQueryable<Category>> GetAll()
        { 
            return await _categoryRepository.FindAll();
        }

        public async Task<IQueryable> GetCategories() {
            return await _categoryRepository.GetCategories();
        }


        public Category Save(Category category)
        {
             return _categoryRepository.Save(category);
        }

        public async Task<Category> DeleteById(Guid Id)
        { 
            return await _categoryRepository.DeleteById(Id);
        }

        public async Task<Category> Update(Category model)
        {
            return await _categoryRepository.Modify(model);
        }

        public async Task<Category> GetById(Guid id)
        {
            return await _categoryRepository.GetById(id);
        }
    }
}
