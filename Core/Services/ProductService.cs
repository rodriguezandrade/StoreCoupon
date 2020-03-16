using AutoMapper;
using Core.Services.Interfaces;
using Repository.Models;
using Repository.Models.Dtos;
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
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IQueryable<ProductDto>> GetAll()
        {
            var query = await _productRepository.FindAll();
            return _mapper.Map<List<ProductDto>>(query).AsQueryable();
        }

        public void Save(ProductDto category)
        {
            category.Id = new Guid();
            var query = _mapper.Map<Product>(category);
            _productRepository.Create(query);
        }

        public async Task<ProductDto> DeleteById(Guid Id)
        {
            var modelToDelete = await _productRepository.FindByCondition(x => x.Id == Id);
            _productRepository.Delete(modelToDelete.FirstOrDefault());
            return _mapper.Map<ProductDto>(modelToDelete.FirstOrDefault());
        }

        public async Task<ProductDto> Update(ProductDto owner)
        {
            var modelToUpdate = await _productRepository.FindByCondition(x => x.Id == owner.Id);
            var model = modelToUpdate.FirstOrDefault();
            var entity = _mapper.Map<Product>(model);
            model = entity;
            _productRepository.Update(model);
            return _mapper.Map<ProductDto>(modelToUpdate.FirstOrDefault());
        }

        public async Task<ProductDto> GetById(Guid id)
        {
            var query = await _productRepository.FindByCondition(x => x.Id == id);
            return _mapper.Map<ProductDto>(query.FirstOrDefault());
        }
        public async Task SaveChanges()
        {
            await _productRepository.SaveChange();
        }
    }
}