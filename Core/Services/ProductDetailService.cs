using AutoMapper;
using Core.Services.Interfaces;
using Repository.Models;
using Repository.Models.Dtos;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<IQueryable<ProductDetailDtl>> GetProducts()
        {
            var query = await _repositoryWrapper.GetProductDetails();
            return _mapper.Map<List<ProductDetailDtl>>(query).AsQueryable();
        }

        public async Task<IQueryable<ProductDetailDto>> GetAll()
        {
            var query = await _productDetailRepository.FindAll();
            return _mapper.Map<List<ProductDetailDto>>(query).AsQueryable();
        }

        public void Save(ProductDetailDto sc)
        {
            sc.Id = new Guid();
            var query = _mapper.Map<ProductDetail>(sc);
            _productDetailRepository.Create(query);
        }

        public async Task<ProductDetailDto> DeleteById(Guid Id)
        {
            var modelToDelete = await _productDetailRepository.FindByCondition(x => x.Id == Id);
            _productDetailRepository.Delete(modelToDelete.FirstOrDefault());
            return _mapper.Map<ProductDetailDto>(modelToDelete.FirstOrDefault());
        }

        public async Task<ProductDetailDto> Update(ProductDetailDto SC)
        {
            var modelToUpdate = await _productDetailRepository.FindByCondition(x => x.Id == SC.Id);
            var model = modelToUpdate.FirstOrDefault();
            var entity = _mapper.Map<ProductDetail>(SC);
            model = entity;
            _productDetailRepository.Update(model);
            return SC;
        }

        public async Task<ProductDetailDto> GetById(Guid id)
        {
            var query = await _productDetailRepository.FindByCondition(x => x.Id == id);
            return _mapper.Map<ProductDetailDto>(query.FirstOrDefault());
        }
        public async Task SaveChanges()
        {
            await _productDetailRepository.SaveChange();
        }
    }
}

