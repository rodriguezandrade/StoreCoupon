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
    public class GeneralCategoryRepository : RepositoryBase<GeneralCategory>, IGeneralCategoryRepository
    {
        private IRepositoryWrapper _repositoryWrapper;
        private RepositoryContext _repositoyContex;
        public GeneralCategoryRepository
           (
            RepositoryContext repositoryContext,
            IRepositoryWrapper repositoryWrapper
           )
             : base(repositoryContext)
        {
            _repositoryWrapper = repositoryWrapper;
            _repositoyContex = repositoryContext;
        }

        public async Task<IQueryable<GeneralCategory>> GetAll()
        {
            return await _repositoryWrapper.Category.FindAll();
        }

        public GeneralCategory Save(GeneralCategory model)
        {
            _repositoryWrapper.Category.Create(model);
            _repositoryWrapper.save();

            return model;
        }

        public async Task<IQueryable> GetCategories()
        {
            List<GeneralCategory> categories = new List<GeneralCategory>();
            categories = await this.RepositoryContext.Set<GeneralCategory>().AsNoTracking().ToListAsync();
            var query = from cat in categories select new { cat.Name , cat.Id};
            return query.AsQueryable();
        }

        public async Task<GeneralCategory> DeleteById(Guid Id)
        {
            var modelToEliminate = await _repositoryWrapper.Category
                                     .FindByCondition(x => x.Id == Id);
            _repositoryWrapper.Category.Delete(modelToEliminate.FirstOrDefault());
            _repositoryWrapper.save();
            return modelToEliminate.FirstOrDefault();
        }

        public async Task<GeneralCategory> Modify(GeneralCategory model)
        {
            var entity = await _repositoryWrapper.Category.FindByCondition(item => item.Id == model.Id);
            entity.FirstOrDefault().Name = model.Name;
            _repositoryWrapper.Category.Update(entity.FirstOrDefault());
            _repositoryWrapper.save();
            return model;
        }

        public async Task<GeneralCategory> GetById(Guid id)
        {
            var query= await _repositoryWrapper.Category.FindByCondition(item => item.Id == id);
            return query.FirstOrDefault();
        }

    }
}
