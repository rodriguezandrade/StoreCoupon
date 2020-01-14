using Repository.Data;
using Repository.Repositories.Utils;
using Repository.Repositories.Interfaces;
using Repository.Models;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        private IRepositoryWrapper _repositoryWrapper;

        public CategoryRepository
           (
            RepositoryContext repositoryContext,
            IRepositoryWrapper repositoryWrapper
           )
             : base(repositoryContext)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<IQueryable<Category>> GetAll()
        {
            return await _repositoryWrapper.Category.FindAll();
        }

        public Category Save(Category model)
        {
            _repositoryWrapper.Category.Create(model);
            _repositoryWrapper.save();

            return model;
        }

        public async Task<Category> DeleteByName(string name)
        {
            var modelToEliminate = await _repositoryWrapper.Category
                                     .FindByCondition(x => x.Name == name);
            _repositoryWrapper.Category.Delete(modelToEliminate.FirstOrDefault());
            _repositoryWrapper.save();
            return modelToEliminate.FirstOrDefault();
        }

        public async Task<Category> Modify(Category model)
        {
            var entity = await _repositoryWrapper.Category.FindByCondition(item => item.Id == model.Id);
            entity.FirstOrDefault().Name = model.Name;
            _repositoryWrapper.Category.Update(entity.FirstOrDefault());
            _repositoryWrapper.save();
            return model;
        }

        public async Task<Category> GetById(Guid id)
        {
            var query= await _repositoryWrapper.Category.FindByCondition(item => item.Id == id);
            return query.FirstOrDefault();
        }

    }
}
