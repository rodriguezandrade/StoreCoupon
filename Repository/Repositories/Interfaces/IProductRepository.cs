using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<IQueryable<Product>> GetAll();
        Product Save(Product model);
        Task<Product> DeleteById(Guid Id);
        Task<Product> Modify(Product model);
        Task<Product> GetById(Guid id);
        Task<IQueryable> GetProducto();
    }
}
