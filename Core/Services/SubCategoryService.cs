using Core.Services.Interfaces;
using Repository.Models;
using Repository.Repositories.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Repository.Models.Dtos;
using Repository.Repositories.Utils;
using AutoMapper;
using System.Collections.Generic;

namespace Core.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IRepositoryWrapper _subCategoryRepositoryWrapper;
        private readonly IMapper _mapper;


        public SubCategoryService(ISubCategoryRepository subCategoryRepository, IMapper mapper, IRepositoryWrapper subCategoryRepositoryWrapper)
        {
            _subCategoryRepository = subCategoryRepository;
            _mapper = mapper;
            _subCategoryRepositoryWrapper = subCategoryRepositoryWrapper;
        }

       
        public async Task<IQueryable<SubCategoryDto>> FindAll()
        {
            var query = await _subCategoryRepository.FindAll();
            return _mapper.Map<List<SubCategoryDto>>(query).AsQueryable();
        }

        public async Task<IQueryable<SubCategoryDetails>> GetAll()
        {
            var query = _subCategoryRepositoryWrapper.GetSubCategoriess().ToList();
            var result = _mapper.Map<List<SubCategoryDetails>>(query);
            return result.AsQueryable();
        }

       public void Save(SubCategoryDto subcategory)
        {
            subcategory.Id = new Guid();
            var query = _mapper.Map<SubCategory>(subcategory);
            _subCategoryRepository.Create(query);
        }

        public async Task<SubCategoryDto> DeleteById(Guid Id)
        {
            var modelToDelete = await _subCategoryRepository.FindByCondition(x => x.Id == Id);
            _subCategoryRepository.Delete(modelToDelete.FirstOrDefault());
            return _mapper.Map<SubCategoryDto>(modelToDelete.FirstOrDefault());
        }

        public async Task<SubCategoryDto> Update(SubCategoryDto subcategory)
        {
            var modelToUpdate = await _subCategoryRepository.FindByCondition(x => x.Id == subcategory.Id);
            var model = modelToUpdate.FirstOrDefault();
            var entity = _mapper.Map<SubCategory>(model);
            model = entity;
            _subCategoryRepository.Update(model);
            return _mapper.Map<SubCategoryDto>(modelToUpdate.FirstOrDefault());
        }

        public async Task<SubCategoryDto> GetById(Guid id)
        {
            var query = await _subCategoryRepository.FindByCondition(x => x.Id == id);
            return _mapper.Map<SubCategoryDto>(query.FirstOrDefault());
        }
        public async Task SaveChanges() {
            await _subCategoryRepository.SaveChange();
        }
    }
}