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

        public async Task<IQueryable<CategoryStoreDto>> Get()
        {
            var query = await _categoryRepository.FindAll();
            return _mapper.Map<List<CategoryStoreDto>>(query).AsQueryable();
        }

        public void Save(CategoryStoreDto category)
        {
            category.Id = new Guid();
            var query = _mapper.Map<CategoryStore>(category);
            _categoryRepository.Create(query);
            _categoryRepository.SaveChanges();
        }

        public async Task<CategoryStoreDto> DeleteById(Guid Id)
        {
            var modelToDelete = await _categoryRepository.FindByCondition(x => x.Id == Id);
            _categoryRepository.Delete(modelToDelete.FirstOrDefault());
            return _mapper.Map<CategoryStoreDto>(modelToDelete.FirstOrDefault());
        }

        public async Task<CategoryStoreDto> Update(CategoryStoreDto category)
        {
            var entity = _mapper.Map<CategoryStore>(category);
            var modelToUpdate = await _categoryRepository.FindByCondition(x => x.Id == entity.Id);
            if (!modelToUpdate.Any())
            {
                throw new ApiException("No se pudo editar la categoryStore", HttpStatusCode.NotFound);
            }
            _categoryRepository.Update(entity);
            return _mapper.Map<CategoryStoreDto>(entity);
        }

        public async Task<CategoryStoreDto> GetById(Guid id)
        {
            var query = await _categoryRepository.FindByCondition(x => x.Id == id);
            return _mapper.Map<CategoryStoreDto>(query.FirstOrDefault());
        } 
    }
}