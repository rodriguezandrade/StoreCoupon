﻿using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Models;
using Repository.Models.Dtos;
using Repository.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq; 
using System.Threading.Tasks;

namespace Repository.Repositories.Utils
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private IGeneralCategoryRepository  _categoryRepository;
        private IRepositoryWrapper  _repositoryWraper;
        private RepositoryContext _repositoryContext; 

        public IGeneralCategoryRepository Category
        {
            get
            {
                switch (_categoryRepository)
                {
                    case null:
                        _categoryRepository = new GeneralCategoryRepository(_repositoryContext, _repositoryWraper);
                        break;
                }

                return _categoryRepository;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        //include Subcategories
        public List<SubCategory>GetSubCategories() {
            return _repositoryContext.SubCategories
                .Include(x=>x.Category)
                .ToList();
        }

        //include Coupons
        public async Task<IQueryable<Coupon>> GetCoupons() { 
            var query =  await  _repositoryContext.Coupons
                .Include(x => x.ProductDetail)
                .ToListAsync();
            return query.AsQueryable();
        }

        //include Store_Categories
        public async Task<IQueryable<StoreCategoryDetail>> GetStoreCategories() {
            var query = await _repositoryContext.StoresCategoryDetails
                .Include(x => x.StoreCategory)
                .Include(x => x.Store)
                .ToListAsync();
            return query.AsQueryable();
        }

        //include ProductDetails
        public async Task<IQueryable<ProductDetail>> GetProductDetails()
        {
            var query = await _repositoryContext.ProductDetails
                .Include(x => x.Product)
                .Include(x=> x.StoreCategoryDetail)
                .ToListAsync();
            return query.AsQueryable();
        }

        //include Stores
        public async Task<IQueryable<Store>> GetStores() {
            var query = await _repositoryContext.Stores
                .Include(x => x.SubCategory)
                //.Include(x=>x.UserDetail)
                .ToListAsync();
            return query.AsQueryable();
        }

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
