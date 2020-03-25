
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
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;
        public OwnerService(IOwnerRepository ownerRepository, IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _mapper = mapper;
        }

        public async Task<IQueryable<OwnerDto>> GetAll()
        {
            var query = await _ownerRepository.FindAll();
            return _mapper.Map<List<OwnerDto>>(query).AsQueryable();
        }

        public void Save(OwnerDto owner)
        {
            var query = _mapper.Map<Owner>(owner);
            _ownerRepository.Create(query);
            _ownerRepository.SaveChanges();
        }

        public async Task<OwnerDto> DeleteById(Guid Id)
        {
            var modelToDelete = await _ownerRepository.FindByCondition(x => x.Id == Id);
            _ownerRepository.Delete(modelToDelete.FirstOrDefault());
            return _mapper.Map<OwnerDto>(modelToDelete.FirstOrDefault());
        }

        public async Task<OwnerDto> Update(OwnerDto owner)
        {
            var entity = _mapper.Map<Owner>(owner);
            var modelToUpdate = await _ownerRepository.FindByCondition(x => x.Id == entity.Id);
            _ownerRepository.Update(modelToUpdate.FirstOrDefault());
            return owner;
        }

        public async Task<OwnerDto> GetById(Guid id)
        {
            var query = await _ownerRepository.FindByCondition(x => x.Id == id);
            return _mapper.Map<OwnerDto>(query.FirstOrDefault());
        }
    }
}