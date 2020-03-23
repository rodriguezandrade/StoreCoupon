using AutoMapper;
using Core.Services.Interfaces;
using Repository.Models;
using Repository.Models.Dtos;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services
{
    public class Store_CategoryService : IStore_CategoryService
    {
        private readonly IStore_CategoryRepository _storecategoryRepository;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;
        public Store_CategoryService(IStore_CategoryRepository storeRepository, IMapper mapper, IRepositoryWrapper repositoryWrapper)
        {
            _storecategoryRepository = storeRepository;
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<IQueryable<Store_CategoryDetails>> GetStoresCategories()
        {
            var query = await _repositoryWrapper.GetStoreCategories();
            return _mapper.Map<List<Store_CategoryDetails>>(query).AsQueryable();
        }

        public async Task<IQueryable<Store_CategoryDto>> GetAll()
        {
            var query = await _storecategoryRepository.FindAll();
            return _mapper.Map<List<Store_CategoryDto>>(query).AsQueryable();
        }

        public void Save(Store_CategoryDto sc)
        {
            sc.Id = new Guid();
            var query = _mapper.Map<Store_Category>(sc);
            _storecategoryRepository.Create(query);
        }

        public async Task<Store_CategoryDto> DeleteById(Guid Id)
        {
            var modelToDelete = await _storecategoryRepository.FindByCondition(x => x.Id == Id);
            _storecategoryRepository.Delete(modelToDelete.FirstOrDefault());
            return _mapper.Map<Store_CategoryDto>(modelToDelete.FirstOrDefault());
        }

        public async Task<Store_CategoryDto> Update(Store_CategoryDto SC)
        {
            var modelToUpdate = await _storecategoryRepository.FindByCondition(x => x.Id == SC.Id);
            var model = modelToUpdate.FirstOrDefault();
            var entity = _mapper.Map<Store_Category>(SC);
            model = entity;
            _storecategoryRepository.Update(model);
            return SC;
        }

        public async Task<Store_CategoryDto> GetById(Guid id)
        {
            var query = await _storecategoryRepository.FindByCondition(x => x.Id == id);
            return _mapper.Map<Store_CategoryDto>(query.FirstOrDefault());
        }
        public async Task SaveChanges()
        {
            await _storecategoryRepository.SaveChange();
        }
    }
}

