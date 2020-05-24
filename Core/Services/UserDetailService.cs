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
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class UserDetailService : IUserDetailService
    {
        private readonly IUserDetailRepository _userDetailRepository;
        private readonly IMapper _mapper;
        public UserDetailService(IUserDetailRepository userRepository, IMapper mapper)
        {
            _userDetailRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IQueryable<UserDetailDto>> Get()
        {
            var query = await _userDetailRepository.FindAll();
            return _mapper.Map<List<UserDetailDto>>(query).AsQueryable();
        }

        public void Save(UserDetailDto user)
        {
            var query = _mapper.Map<UserDetail>(user);
            _userDetailRepository.Create(query);
        }

        public async Task<UserDetailDto> DeleteById(int Id)
        {
            var modelToDelete = await _userDetailRepository.FindByCondition(x => x.Id == Id);
            if (!modelToDelete.Any())
            {
                throw new ApiException("No se pudo Eliminar el usuario ", HttpStatusCode.NotFound);
            }
            _userDetailRepository.Delete(modelToDelete.FirstOrDefault());
            return _mapper.Map<UserDetailDto>(modelToDelete.FirstOrDefault());
        }

        public async Task<UserDetailDto> Update(UserDetailDto user)
        {
            var entity = _mapper.Map<UserDetail>(user);
            var modelToUpdate = await _userDetailRepository.FindByCondition(x => x.Id == entity.Id);
            if (!modelToUpdate.Any())
            {
                throw new ApiException("No se pudo editar el user", HttpStatusCode.NotFound);
            }
            _userDetailRepository.Update(entity);
            return _mapper.Map<UserDetailDto>(entity);
        }

        public async Task<UserDetailDto> GetById(int id)
        {
            var query = await _userDetailRepository.FindByCondition(x => x.Id == id);
            return _mapper.Map<UserDetailDto>(query.FirstOrDefault());
        }

        public async Task<IQueryable<UserDetailDto>> GetOwners()
        {
            var query = await this._userDetailRepository.GetOwners();
            return _mapper.Map<List<UserDetailDto>>(query).AsQueryable();
        }
    }
}
    
