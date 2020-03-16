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
    public class StoreService : IStoreService 
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;
        public StoreService(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        public async Task<IQueryable<StoreDto>> GetAll()
        {
            var query = await _storeRepository.FindAll();
            return _mapper.Map<List<StoreDto>>(query).AsQueryable();
        }

        public void Save(StoreDto store)
        {
            store.Id = new Guid();
            var query = _mapper.Map<Store>(store);
            _storeRepository.Create(query);
        }

        public async Task<StoreDto> DeleteById(Guid Id)
        {
            var modelToDelete = await _storeRepository.FindByCondition(x => x.Id == Id);
            _storeRepository.Delete(modelToDelete.FirstOrDefault());
            return _mapper.Map<StoreDto>(modelToDelete.FirstOrDefault());
        }

        public async Task<StoreDto> Update(StoreDto owner)
        {
            var modelToUpdate = await _storeRepository.FindByCondition(x => x.Id == owner.Id);
            var model = modelToUpdate.FirstOrDefault();
            var entity = _mapper.Map<Store>(model);
            model = entity;
            _storeRepository.Update(model);
            return _mapper.Map<StoreDto>(modelToUpdate.FirstOrDefault());
        }

        public async Task<StoreDto> GetById(Guid id)
        {
            var query = await _storeRepository.FindByCondition(x => x.Id == id);
            return _mapper.Map<StoreDto>(query.FirstOrDefault());
        }
        public async Task SaveChanges()
        {
            await _storeRepository.SaveChange();
        }
    }
}
