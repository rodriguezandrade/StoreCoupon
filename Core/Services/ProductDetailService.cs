using AutoMapper;
using Core.Services.Interfaces;
using Repository.Models;
using Repository.Models.Dtos;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Core.Exceptions;

namespace Core.Services
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IProductDetailRepository _productDetailRepository;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;

        public ProductDetailService(IProductDetailRepository productDetail, IMapper mapper, IRepositoryWrapper repositoryWrapper)
        {
            _productDetailRepository = productDetail;
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<IQueryable<ProductDetailDto>> GetDetails()
        {
            var query = await _repositoryWrapper.GetProductDetails();
            return _mapper.Map<List<ProductDetailDto>>(query).AsQueryable();
        }

        public async Task<IQueryable<ProductDetailDto>> Get()
        {
            var query = await _productDetailRepository.FindAll();
            return _mapper.Map<List<ProductDetailDto>>(query).AsQueryable();
        }

        public void Save(ProductDetailDto sc)
        {
            sc.Id = new Guid();
            var query = _mapper.Map<ProductDetail>(sc);
            _productDetailRepository.Create(query);
            _productDetailRepository.SaveChanges();
        }

        public async Task<ProductDetailDto> DeleteById(Guid Id)
        {
            var modelToDelete = await _productDetailRepository.FindByCondition(x => x.Id == Id);
            _productDetailRepository.Delete(modelToDelete.FirstOrDefault());
            return _mapper.Map<ProductDetailDto>(modelToDelete.FirstOrDefault());
        }

        public async Task<ProductDetailDto> Update(ProductDetailDto productDetailDto)
        {
            var entity = _mapper.Map<ProductDetail>(productDetailDto);
            var modelToUpdate = await _productDetailRepository.FindByCondition(x => x.Id == entity.Id);
            if (!modelToUpdate.Any())
            {
                throw new ApiException("No se pudo editar el ProductDetail", HttpStatusCode.NotFound);
            }

            _productDetailRepository.Update(entity);
            return _mapper.Map<ProductDetailDto>(entity);
        }

        public async Task<ProductDetailDto> GetById(Guid id)
        {
            var query = await _productDetailRepository.FindByCondition(x => x.Id == id);
            return _mapper.Map<ProductDetailDto>(query.FirstOrDefault());
        }
    }
}

