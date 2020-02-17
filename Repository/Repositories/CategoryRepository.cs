using Repository.Data;
using Repository.Repositories.Utils;
using Repository.Repositories.Interfaces;
using Repository.Models;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        private IRepositoryWrapper _repositoryWrapper;
        private RepositoryContext _repositoyContex;
        public CategoryRepository
           (
            RepositoryContext repositoryContext,
            IRepositoryWrapper repositoryWrapper
           )
             : base(repositoryContext)
        {
            _repositoryWrapper = repositoryWrapper;
            _repositoyContex = repositoryContext;
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

        public async Task<IQueryable> GetCategories()
        {
            List<Category> categories = new List<Category>();
            categories = await this.RepositoryContext.Set<Category>().AsNoTracking().ToListAsync();
            var query = from cat in categories select new { cat.Name , cat.Id};
            return query.AsQueryable();
        }

        public async Task<Category> DeleteById(Guid Id)
        {
            var modelToEliminate = await _repositoryWrapper.Category
                                     .FindByCondition(x => x.Id == Id);
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
