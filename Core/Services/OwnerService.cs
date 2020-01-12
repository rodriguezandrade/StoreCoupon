
using Core.Services.Interfaces;
using Repository.Models;
using Repository.Repositories.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

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
            entity.OwnerId = new Guid();
            _ownerRepository.Create(entity);
        }

        public void Delete(Owner entity)
        {
            _ownerRepository.Delete(entity);
        }

        public IQueryable<Owner> FindAll()
        {
           return  _ownerRepository.FindAll();
        
        }

        public IQueryable<Owner> FindByCondition(Expression<Func<Owner, bool>> expression)
        {
            return _ownerRepository.FindByCondition(expression);
        }

        public void Update(Owner entity)
        {
            _ownerRepository.Update(entity);
        }

        public void SaveChage() {
            _ownerRepository.SaveChange();
        }
    }
}
