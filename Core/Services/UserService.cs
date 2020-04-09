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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IQueryable<UserDto>> Get()
        {
            var query = await _userRepository.FindAll();
            return _mapper.Map<List<UserDto>>(query).AsQueryable();
        }

        public void Save(UserDto user)
        {
            var query = _mapper.Map<User>(user);
            _userRepository.Create(query);
        }

        public async Task<UserDto> DeleteById(Guid Id)
        {
            var modelToDelete = await _userRepository.FindByCondition(x => x.Id == Id);
            _userRepository.Delete(modelToDelete.FirstOrDefault());
            return _mapper.Map<UserDto>(modelToDelete.FirstOrDefault());
        }

        public async Task<UserDto> Update(UserDto user)
        {
            var entity = _mapper.Map<User>(user);
            var modelToUpdate = await _userRepository.FindByCondition(x => x.Id == entity.Id);
            if (!modelToUpdate.Any())
            {
                throw new ApiException("No se pudo editar el user", HttpStatusCode.NotFound);
            }
            _userRepository.Update(entity);
            return _mapper.Map<UserDto>(entity);
        }

        public async Task<UserDto> GetById(Guid id)
        {
            var query = await _userRepository.FindByCondition(x => x.Id == id);
            return _mapper.Map<UserDto>(query.FirstOrDefault());
        }
    }
}