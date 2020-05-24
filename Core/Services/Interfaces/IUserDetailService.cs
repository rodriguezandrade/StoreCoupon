using Repository.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IUserDetailService
    {
        Task<IQueryable<UserDetailDto>> Get();
        void Save(UserDetailDto category);
        Task<UserDetailDto> DeleteById(int Id);
        Task<UserDetailDto> Update(UserDetailDto user);
        Task<UserDetailDto> GetById(int id);
        Task<IQueryable<UserDetailDto>> GetOwners();
    }
}
