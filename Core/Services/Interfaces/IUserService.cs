﻿using Repository.Models.Dtos;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IUserService
    {
        Task<IQueryable<UserDto>> Get();
        void Save(UserDto category);
        Task<UserDto> DeleteById(int Id);
        Task<UserDto> Update(UserDto user);
        Task<UserDto> GetById(int id);
    }
}
