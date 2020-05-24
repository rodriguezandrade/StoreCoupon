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

        public async Task<IQueryable<StoreCategoryDto>> Get()
        {
            var query = await _categoryRepository.FindAll();
          
            return _mapper.Map<List<StoreCategoryDto>>(query).AsQueryable();
        }

        public void Save(StoreCategoryDto storeCategory)
        {
            var query = _mapper.Map<StoreCategoy>(storeCategory);
            _categoryRepository.Create(query);
        }

        public async Task<StoreCategoryDto> DeleteById(Guid Id)
        {
            var modelToDelete = await _categoryRepository.FindByCondition(x => x.Id == Id);
            if (!modelToDelete.Any())
            {
                throw new ApiException("No se pudo Eliminar la categoria ", HttpStatusCode.NotFound);
            }

            _categoryRepository.Delete(modelToDelete.FirstOrDefault());
            return _mapper.Map<StoreCategoryDto>(modelToDelete.FirstOrDefault());
        }

        public async Task<StoreCategoryDto> Update(StoreCategoryDto storeCategory)
        {
            var entity = _mapper.Map<StoreCategoy>(storeCategory);
            var modelToUpdate = await _categoryRepository.FindByCondition(x => x.Id == entity.Id);
            if (!modelToUpdate.Any())
            {
                throw new ApiException("No se pudo editar la categoryStore", HttpStatusCode.NotFound);
            }
            _categoryRepository.Update(entity);
            return _mapper.Map<StoreCategoryDto>(entity);
        }

        public async Task<StoreCategoryDto> GetById(Guid id)
        {
            var query = await _categoryRepository.FindByCondition(x => x.Id == id);
            return _mapper.Map<StoreCategoryDto>(query.FirstOrDefault());
        }
    }
}