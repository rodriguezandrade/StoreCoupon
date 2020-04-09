using AutoMapper;
using Core.Exceptions;
using Core.Services.Interfaces;
using Repository.Models;
using Repository.Models.Dtos;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public async Task<IQueryable<ProductDto>> Get()
        {
            var query = await _productRepository.FindAll();
            return _mapper.Map<List<ProductDto>>(query).AsQueryable();
        }

        public void Save(ProductDto product)
        {
            
            var query = _mapper.Map<Product>(product);
            _productRepository.Create(query);
            _productRepository.SaveChanges();
        }

        public async Task<ProductDto> DeleteById(Guid Id)
        {
            var modelToDelete = await _productRepository.FindByCondition(x => x.Id == Id);
            _productRepository.Delete(modelToDelete.FirstOrDefault());
            return _mapper.Map<ProductDto>(modelToDelete.FirstOrDefault());
        }

        public async Task<ProductDto> Update(ProductDto product)
        {
            var entity = _mapper.Map<Product>(product);
            var modelToUpdate = await _productRepository.FindByCondition(x => x.Id == entity.Id);
            if (!modelToUpdate.Any())
            {
                throw new ApiException("No se pudo editar el product", HttpStatusCode.NotFound);
            }
            _productRepository.Update(entity);
            return _mapper.Map<ProductDto>(entity);
        }

        public async Task<ProductDto> GetById(Guid id)
        {
            var query = await _productRepository.FindByCondition(x => x.Id == id);
            return _mapper.Map<ProductDto>(query.FirstOrDefault());
        }
    }
}