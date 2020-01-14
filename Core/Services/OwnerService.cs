
using Core.Services.Interfaces;
using Repository.Models;
using Repository.Repositories.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public void Create(Owner entity)
        {
            entity.Id = new Guid();
            _ownerRepository.Create(entity);
        }

        public void Delete(Owner entity)
        {
            _ownerRepository.Delete(entity);
        }

        public async Task<IQueryable<Owner>> FindAll()
        {
           return await _ownerRepository.FindAll();
        }

        public async Task<IQueryable<Owner>> FindByCondition(Expression<Func<Owner, bool>> expression)
        {
            return await _ownerRepository.FindByCondition(expression);
        }

        public void Update(Owner entity)
        {
            _ownerRepository.Update(entity);
        }

        public async Task SaveChage() {
          await _ownerRepository.SaveChange();
        }

        public async Task<Owner> DeleteByRFC(string RFC) {
            var modelToDelete = await _ownerRepository.FindByCondition(x => x.RFC == RFC);
            _ownerRepository.Delete(modelToDelete.FirstOrDefault());
            await _ownerRepository.SaveChange();
            return modelToDelete.FirstOrDefault();
        }

        public async Task<Owner> Modify(Owner owner) {
            var modelToUpdate = await _ownerRepository.FindByCondition(x => x.Id == owner.Id);
            var model = modelToUpdate.FirstOrDefault();
            model = owner;
            _ownerRepository.Update(model);
            return modelToUpdate.FirstOrDefault();
        }
    }
}
