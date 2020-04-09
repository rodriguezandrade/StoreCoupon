using Repository.Data;
using Repository.Repositories.Utils;
using Repository.Repositories.Interfaces;
using Repository.Models;
using System.Linq;
using System;
using System.Threading.Tasks; 
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    public class GeneralCategoryRepository : RepositoryBase<GeneralCategory>, IGeneralCategoryRepository
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        public GeneralCategoryRepository
           (
            RepositoryContext repositoryContext,
            IRepositoryWrapper repositoryWrapper
           )
             : base(repositoryContext)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<IQueryable<GeneralCategory>> GetAll()
        {
            return await _repositoryWrapper.Category.FindAll();
        }

        public GeneralCategory Save(GeneralCategory model)
        {
            _repositoryWrapper.Category.Create(model);
            return model;
        }

        public async Task<IQueryable> GetCategories()
        {
            var categories = await RepositoryContext.Set<GeneralCategory>()
                .AsNoTracking()
                .ToListAsync();
            var query = from cat in categories select new { cat.Name, cat.Id };
            return query.AsQueryable();
        }

        public async Task<GeneralCategory> DeleteById(IQueryable<GeneralCategory> modelToEliminate)
        {
            _repositoryWrapper.Category.Delete(modelToEliminate.FirstOrDefault());
            return modelToEliminate.FirstOrDefault();
        }

        public async Task<GeneralCategory> Modify(GeneralCategory model)
        {
            var entity = await _repositoryWrapper.Category
                .FindByCondition(item => item.Id == model.Id);

            entity.FirstOrDefault().Name = model.Name;
            _repositoryWrapper.Category.Update(entity.FirstOrDefault());
            return model;
        }

        public async Task<GeneralCategory> GetById(Guid id)
        {
            var query = await _repositoryWrapper.Category.FindByCondition(item => item.Id == id);
            return query.FirstOrDefault();
        }
    }
}
