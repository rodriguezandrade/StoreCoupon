using Core.Services.Interfaces;
using Repository.Models;
using Repository.Repositories.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Repository.Models.Dtos;

namespace Core.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository;

        public SubCategoryService(ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public void Create(SubCategory entity)
        {
            entity.Id = new Guid();
            _subCategoryRepository.Create(entity);
        }

        public void Delete(SubCategory entity)
        {
            _subCategoryRepository.Delete(entity);
        }

        public async Task<IQueryable<SubCategory>> FindAll()
        {
            return await _subCategoryRepository.FindAll();
        }

        public async Task<IQueryable<SubCategoryDto>> GetAll() {
            return await _subCategoryRepository.Get();
        }

    

        public async Task<IQueryable<SubCategory>> FindByCondition(Expression<Func<SubCategory, bool>> expression)
        {
            return await _subCategoryRepository.FindByCondition(expression);
        }

        public void Update(SubCategory entity)
        {
            _subCategoryRepository.Update(entity);
        }

        public async Task SaveChage()
        {
            await _subCategoryRepository.SaveChange();
        }

        public async Task<SubCategory> DeleteById(Guid Id)
        {
            var modelToDelete = await _subCategoryRepository.FindByCondition(x => x.Id == Id);
            _subCategoryRepository.Delete(modelToDelete.FirstOrDefault());
            return modelToDelete.FirstOrDefault();
        }

        public async Task<SubCategory> Modify(SubCategory owner)
        {
            var modelToUpdate = await _subCategoryRepository.FindByCondition(x => x.Id == owner.Id);
            var model = modelToUpdate.FirstOrDefault();
            model = owner;
            _subCategoryRepository.Update(model);
            return modelToUpdate.FirstOrDefault();
        }


    }
}
