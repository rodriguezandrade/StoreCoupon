using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IProductService
    {
        void Create(Product entity);
        void Delete(Product entity);
        Task<IQueryable<Product>> FindAll();
        Task<IQueryable<Product>> FindByCondition(Expression<Func<Product, bool>> expression);
        void Update(Product entity);
        Task SaveChage();
        Task<Product> DeleteById(Guid Id);
        Task<Product> Modify(Product Product);
    }
}
