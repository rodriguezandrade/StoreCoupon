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

        public async Task<IQueryable<StoreCategoryDetailDto>> GetDetails()
        {
            var query = await _repositoryWrapper.GetStoreCategories();
            return _mapper.Map<List<StoreCategoryDetailDto>>(query).AsQueryable();
        }

        public async Task<IQueryable<StoreCategoryDetailDto>> Get()
        {
            var query = await _storeCategoryRepository.FindAll();
            return _mapper.Map<List<StoreCategoryDetailDto>>(query).AsQueryable();
        }

        public void Save(StoreCategoryDetailDto sc)
        {
            var query = _mapper.Map<StoreCategoryDetail>(sc);
            _storeCategoryRepository.Create(query);
        }

        public async Task<StoreCategoryDetailDto> DeleteById(Guid Id)
        {
            var modelToDelete = await _storeCategoryRepository.FindByCondition(x => x.Id == Id);
            _storeCategoryRepository.Delete(modelToDelete.FirstOrDefault());
            return _mapper.Map<StoreCategoryDetailDto>(modelToDelete.FirstOrDefault());
        }

        public async Task<StoreCategoryDetailDto> Update(StoreCategoryDetailDto storeCategoryDetail)
        {
            var entity = _mapper.Map<StoreCategoryDetail>(storeCategoryDetail);
            var modelToUpdate = await _storeCategoryRepository.FindByCondition(x => x.Id == entity.Id);
            if (!modelToUpdate.Any())
            {
                throw new ApiException("No se pudo editar el storeCategoryDetail", HttpStatusCode.NotFound);
            }
            _storeCategoryRepository.Update(entity);
            return _mapper.Map<StoreCategoryDetailDto>(entity);
        }

        public async Task<StoreCategoryDetailDto> GetById(Guid id)
        {
            var query = await _storeCategoryRepository.FindByCondition(x => x.Id == id);
            return _mapper.Map<StoreCategoryDetailDto>(query.FirstOrDefault());
        }
    }
}

