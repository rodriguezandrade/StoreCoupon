using Core.Services.Interfaces;
using Repository.Models;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> DeleteById(Guid Id)
        {
            return await _productRepository.DeleteById(Id);
        }

        public async Task<IQueryable<Product>> GetAll()
        {
            return await _productRepository.FindAll();
        }

        public async Task<Product> GetById(Guid id)
        {
            return await _productRepository.GetById(id);
        }

        public async Task<IQueryable> GetProduct()
        {
            return await _productRepository.GetProducto();
        }

        public Product Save(Product model)
        {
            return _productRepository.Save(model);
        }

        public async Task<Product> Update(Product model)
        {
            return await _productRepository.Modify(model);
        }
    }
}
