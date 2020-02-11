

using Repository.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IStoreService
    {
        void Create(Store entity);
        void Delete(Store entity);
        Task<IQueryable<Store>> FindAll();
        Task<IQueryable<Store>> FindByCondition(Expression<Func<Store, bool>> expression);
        void Update(Store entity);
        Task SaveChage();
        Task<Store> DeleteById(Guid Id);
        Task<Store> Modify(Store owner);
    }
}
