using AutoMapper;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository.Models.Dtos;
using Repository.Models;
using Core.Services.Interfaces;
using Core.Exceptions;
using System.Net;

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

        public async Task<IQueryable<CategoryOfStoreDto>> Get()
        {
            var query = await _categoryRepository.FindAll();
            return _mapper.Map<List<CategoryOfStoreDto>>(query).AsQueryable();
        }

        public void Save(CategoryOfStoreDto category)
        {
            category.Id = new Guid();
            var query = _mapper.Map<CategoryOfStore>(category);
            _categoryRepository.Create(query);
            _categoryRepository.SaveChanges();
        }

        public async Task<CategoryOfStoreDto> DeleteById(Guid Id)
        {
            var modelToDelete = await _categoryRepository.FindByCondition(x => x.Id == Id);
            _categoryRepository.Delete(modelToDelete.FirstOrDefault());
            return _mapper.Map<CategoryOfStoreDto>(modelToDelete.FirstOrDefault());
        }

        public async Task<CategoryOfStoreDto> Update(CategoryOfStoreDto category)
        {
            var entity = _mapper.Map<CategoryOfStore>(category);
            var modelToUpdate = await _categoryRepository.FindByCondition(x => x.Id == entity.Id);
            if (!modelToUpdate.Any())
            {
                throw new ApiException("No se pudo editar la categoryStore", HttpStatusCode.NotFound);
            }
            _categoryRepository.Update(entity);
            return _mapper.Map<CategoryOfStoreDto>(entity);
        }

        public async Task<CategoryOfStoreDto> GetById(Guid id)
        {
            var query = await _categoryRepository.FindByCondition(x => x.Id == id);
            return _mapper.Map<CategoryOfStoreDto>(query.FirstOrDefault());
        }
    }
}