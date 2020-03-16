using AutoMapper;
using Core.Services.Interfaces;
using Repository.Models;
using Repository.Models.Dtos;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CouponService : ICouponService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly ICouponRepository _couponRepository;
        public CouponService(ICouponRepository couponRepository, IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _mapper = mapper;
            _couponRepository = couponRepository;
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<IQueryable<CouponDetails>> GetCoupons() {
            var query = await  _repositoryWrapper.GetCoupons();
             return _mapper.Map<List<CouponDetails>>(query).AsQueryable();
           
        }
        public void create(CouponDto entity) {
            entity.Id = new Guid();
            var model = _mapper.Map<Coupon>(entity);
            _couponRepository.Create(model);
        }

        public async Task<IQueryable<CouponDetails>> FindAll() {
            var query = await _couponRepository.FindAll();
            return _mapper.Map<IQueryable<CouponDetails>>(query).AsQueryable();
        }

        public async Task<CouponDetails> FindByCondition(Guid idCoupon) {
            var query = await _couponRepository.FindByCondition(x => x.Id == idCoupon);
            return _mapper.Map<CouponDetails>(query.FirstOrDefault());
        }

        public async Task<CouponDto> Modify(CouponDto coupon) {
            var modelToUpdate = await _couponRepository.FindByCondition(x => x.Id == coupon.Id);
            var model = modelToUpdate.FirstOrDefault();
            var entity = _mapper.Map<Coupon>(coupon);
            model = entity;
            _couponRepository.Update(model);
            return _mapper.Map<CouponDto>(modelToUpdate.FirstOrDefault());
            
        }

        public async Task<CouponDto> DeleteById(Guid id) {
            var modelToDelete = await _couponRepository.FindByCondition(x => x.Id == id);
            _couponRepository.Delete(modelToDelete.FirstOrDefault());
            return _mapper.Map<CouponDto>(modelToDelete.FirstOrDefault());
        }
        public async Task SaveChage()
        {
            await _couponRepository.SaveChange();
        }
    }
}
