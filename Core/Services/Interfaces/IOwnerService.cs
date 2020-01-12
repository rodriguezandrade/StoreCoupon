

using Repository.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Core.Services.Interfaces
{
    public interface IOwnerService
    {
        void Create(Owner entity);
        void Delete(Owner entity);
        IQueryable<Owner> FindAll();
        IQueryable<Owner> FindByCondition(Expression<Func<Owner, bool>> expression);
        void Update(Owner entity);
        void SaveChage();
    }
}
