﻿

using Repository.Models.Dtos;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IStoreService
    {
        Task<IQueryable<StoreDto>> GetAll();
        Task<IQueryable<StoreDetails>> GetStores();
        void Save(StoreDto category);
        Task<StoreDto> DeleteById(Guid Id);
        Task<StoreDto> Update(StoreDto owner);
        Task<StoreDto> GetById(Guid id);
        Task SaveChanges();
    }
}
