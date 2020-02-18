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

        public async Task<IQueryable<GeneralCategory>> GetAll()
        { 
            return await _categoryRepository.FindAll();
        }

        public async Task<IQueryable> GetCategories() {
            return await _categoryRepository.GetCategories();
        }


        public GeneralCategory Save(GeneralCategory category)
        {
             return _categoryRepository.Save(category);
        }

        public async Task<GeneralCategory> DeleteById(Guid Id)
        { 
            return await _categoryRepository.DeleteById(Id);
        }

        public async Task<GeneralCategory> Update(GeneralCategory model)
        {
            return await _categoryRepository.Modify(model);
        }

        public async Task<GeneralCategory> GetById(Guid id)
        {
            return await _categoryRepository.GetById(id);
        }
    }
}
