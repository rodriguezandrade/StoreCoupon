using Core.Services.Interfaces;
using Repository.Models;
using Repository.Repositories.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Services
{
    public class StoreService : IStoreService 
    {
        private readonly IStoreRepository _storeRepository;
        public StoreService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public void Create(Store entity)
        {
            entity.Id = new Guid();
            _storeRepository.Create(entity);
        }

        public void Delete(Store entity)
        {
            _storeRepository.Delete(entity);
        }

        public async Task<IQueryable<Store>> FindAll()
        {
            return await _storeRepository.FindAll();
        }

        public async Task<IQueryable<Store>> FindByCondition(Expression<Func<Store, bool>> expression)
        {
            return await _storeRepository.FindByCondition(expression);
        }

        public void Update(Store entity)
        {
            _storeRepository.Update(entity);
        }

        public async Task SaveChage()
        {
            await _storeRepository.SaveChange();
        }

        public async Task<Store> DeleteById(Guid Id)
        {
            var modelToDelete = await _storeRepository.FindByCondition(x => x.Id == Id);
            _storeRepository.Delete(modelToDelete.FirstOrDefault());
            return modelToDelete.FirstOrDefault();
        }

        public async Task<Store> Modify(Store owner)
        {
            var modelToUpdate = await _storeRepository.FindByCondition(x => x.Id == owner.Id);
            var model = modelToUpdate.FirstOrDefault();
            model = owner;
            _storeRepository.Update(model);
            return modelToUpdate.FirstOrDefault();
        }
    }
}
