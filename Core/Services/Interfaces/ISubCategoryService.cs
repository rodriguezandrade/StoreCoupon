

using Repository.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Repository.Models.Dtos;
using System.Collections.Generic;

namespace Core.Services.Interfaces
{
    public interface ISubCategoryService
    {
        void Create(SubCategory entity);
        void Delete(SubCategory entity);
        Task<IQueryable<SubCategory>> FindAll();
        Task<IQueryable<SubCategory>> FindByCondition(Expression<Func<SubCategory, bool>> expression);
        void Update(SubCategory entity);
        Task SaveChage();
        Task<SubCategory> DeleteById(Guid Id);
        Task<SubCategory> Modify(SubCategory owner);
        List<SubCategoryDto> GetAll();
    }
}
