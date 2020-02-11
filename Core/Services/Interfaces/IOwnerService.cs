

using Repository.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IOwnerService
    {
        void Create(Owner entity);
        void Delete(Owner entity);
        Task<IQueryable<Owner>> FindAll();
        Task <IQueryable<Owner>> FindByCondition(Expression<Func<Owner, bool>> expression);
        void Update(Owner entity);
        Task SaveChage();
        Task<Owner> DeleteById(Guid Id);
        Task<Owner> Modify(Owner owner);
    }
}
