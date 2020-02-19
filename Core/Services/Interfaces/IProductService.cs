using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IProductService
    {
        Task<IQueryable<Product>> GetAll();
        Product Save(Product product);
        Task<Product> DeleteById(Guid Id);
        Task<Product> Update(Product model);
        Task<Product> GetById(Guid id);
        Task<IQueryable> GetProduct();
    }
}
