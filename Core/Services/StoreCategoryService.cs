using AutoMapper;
using Core.Exceptions;
using Core.Services.Interfaces;
using Repository.Models;
using Repository.Models.Dtos;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Core.Services
{
    public class StoreCategoryService : IStoreCategoryService
    {
        private readonly IStoreCategoryRepository _storeCategoryRepository;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;
        public StoreCategoryService(IStoreCategoryRepository storeRepository, IMapper mapper, IRepositoryWrapper repositoryWrapper)
        {
            _storeCategoryRepository = storeRepository;
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<IQueryable<StoreCategoryDto>> GetDetails()
        {
            var query = await _repositoryWrapper.GetStoreCategories();
            return _mapper.Map<List<StoreCategoryDto>>(query).AsQueryable();
        }

        public async Task<IQueryable<StoreCategoryDto>> Get()
        {
            var query = await _storeCategoryRepository.FindAll();
            return _mapper.Map<List<StoreCategoryDto>>(query).AsQueryable();
        }

        public void Save(StoreCategoryDto sc)
        {
            sc.Id = new Guid();
            var query = _mapper.Map<StoreCategory>(sc);
            _storeCategoryRepository.Create(query);
            _storeCategoryRepository.SaveChanges();
        }

        public async Task<StoreCategoryDto> DeleteById(Guid Id)
        {
            var modelToDelete = await _storeCategoryRepository.FindByCondition(x => x.Id == Id);
            _storeCategoryRepository.Delete(modelToDelete.FirstOrDefault());
            return _mapper.Map<StoreCategoryDto>(modelToDelete.FirstOrDefault());
        }

        public async Task<StoreCategoryDto> Update(StoreCategoryDto storeCategory)
        {
            var entity = _mapper.Map<StoreCategory>(storeCategory);
            var modelToUpdate = await _storeCategoryRepository.FindByCondition(x => x.Id == entity.Id);
            if (!modelToUpdate.Any())
            {
                throw new ApiException("No se pudo editar el storeCategory", HttpStatusCode.NotFound);
            }
            _storeCategoryRepository.Update(entity);
            return _mapper.Map<StoreCategoryDto>(entity);
        }

        public async Task<StoreCategoryDto> GetById(Guid id)
        {
            var query = await _storeCategoryRepository.FindByCondition(x => x.Id == id);
            return _mapper.Map<StoreCategoryDto>(query.FirstOrDefault());
        }
    }
}

