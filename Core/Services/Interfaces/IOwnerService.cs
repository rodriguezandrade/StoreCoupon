﻿

using Repository.Models;
using Repository.Models.Dtos;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IOwnerService
    {
        Task<IQueryable<OwnerDto>> GetAll();
        void Save(OwnerDto category);
        Task<OwnerDto> DeleteById(Guid Id);
        Task<OwnerDto> Update(OwnerDto owner);
        Task<OwnerDto> GetById(Guid id);
        Task SaveChanges();
    }
}
