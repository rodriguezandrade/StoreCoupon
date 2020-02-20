using Core.Services.Interfaces;
using Repository.Models;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public void Create(Product entity)
        {
            entity.Id = new Guid();
            _productRepository.Create(entity);
        }

        public void Delete(Product entity)
        {
            _productRepository.Delete(entity);
        }

        public async Task<Product> DeleteById(Guid Id)
        {
            var modelToDelete = await _productRepository.FindByCondition(x => x.Id == Id);
            _productRepository.Delete(modelToDelete.FirstOrDefault());
            return modelToDelete.FirstOrDefault();
        }

        public async Task<IQueryable<Product>> FindAll()
        {
            return await _productRepository.FindAll();
        }

        public async Task<IQueryable<Product>> FindByCondition(Expression<Func<Product, bool>> expression)
        {
            return await _productRepository.FindByCondition(expression);
        }

        public async Task<Product> Modify(Product Product)
        {
            var modelToUpdate = await _productRepository.FindByCondition(x => x.Id == Product.Id);
            var model = modelToUpdate.FirstOrDefault();
            model = Product;
            _productRepository.Update(model);
            return modelToUpdate.FirstOrDefault();
        }

        public async Task SaveChage()
        {
            await _productRepository.SaveChange();
        }

        public void Update(Product entity)
        {
            _productRepository.Update(entity);
        }
    }
}
