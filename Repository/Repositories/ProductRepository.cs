using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Models;
using Repository.Repositories.Interfaces;
using Repository.Repositories.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        private RepositoryContext _repositoryContext;
        private IRepositoryWrapper _repositoryWraper;

        public ProductRepository(RepositoryContext repositoryContext, IRepositoryWrapper repositoryWraper)
            : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _repositoryWraper = repositoryWraper;
        }

        public async Task<Product> DeleteById(Guid Id)
        {
            var modelToEliminate = await _repositoryWraper.Product
                                     .FindByCondition(x => x.Id == Id);
            _repositoryWraper.Product.Delete(modelToEliminate.FirstOrDefault());
            _repositoryWraper.save();
            return modelToEliminate.FirstOrDefault();
        }

        public async Task<IQueryable<Product>> GetAll()
        {
            return await _repositoryWraper.Product.FindAll();
        }

        public async Task<Product> GetById(Guid id)
        {
            var query = await _repositoryWraper.Product.FindByCondition(item => item.Id == id);
            return query.FirstOrDefault();
        }

        public async Task<IQueryable> GetProducto()
        {
            List<Product> products = new List<Product>();
            products = await this.RepositoryContext.Set<Product>().AsNoTracking().ToListAsync();
            var query = from pro in products select new { pro.Name, pro.Id, pro.Description, pro.Price };
            return query.AsQueryable();
        }

        public async Task<Product> Modify(Product model)
        {
            var entity = await _repositoryWraper.Product.FindByCondition(item => item.Id == model.Id);
            entity.FirstOrDefault().Name = model.Name;
            _repositoryWraper.Product.Update(entity.FirstOrDefault());
            _repositoryWraper.save();
            return model;
        }

        public Product Save(Product model)
        {
            _repositoryWraper.Product.Create(model);
            _repositoryWraper.save();

            return model;
        }
    }
}
