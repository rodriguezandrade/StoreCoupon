using AutoMapper;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository.Models.Dtos;
using Repository.Models;
using Core.Services.Interfaces;

namespace Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IQueryable<CategoryStoreDto>> GetAll()
        {
            var query = await _categoryRepository.FindAll();
            return _mapper.Map<List<CategoryStoreDto>>(query).AsQueryable();
        }

        public void Save(CategoryStoreDto category)
        {
            category.Id = new Guid();
            var query = _mapper.Map<CategoryStore>(category);
            _categoryRepository.Create(query);
        }

        public async Task<CategoryStoreDto> DeleteById(Guid Id)
        {
            var modelToDelete = await _categoryRepository.FindByCondition(x => x.Id == Id);
            _categoryRepository.Delete(modelToDelete.FirstOrDefault());
            return _mapper.Map<CategoryStoreDto>(modelToDelete.FirstOrDefault());
        }

        public async Task<CategoryStoreDto> Update(CategoryStoreDto category)
        {
            var modelToUpdate = await _categoryRepository.FindByCondition(x => x.Id == category.Id);
            var model = modelToUpdate.FirstOrDefault();
            var entity = _mapper.Map<CategoryStore>(category);
            model = entity;
            _categoryRepository.Update(model);
            return category;
        }

        public async Task<CategoryStoreDto> GetById(Guid id)
        {
            var query = await _categoryRepository.FindByCondition(x => x.Id == id);
            return _mapper.Map<CategoryStoreDto>(query.FirstOrDefault());
        }
        public async Task SaveChanges()
        {
            await _categoryRepository.SaveChange();
        }
    }
}