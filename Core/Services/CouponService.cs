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
            _couponRepository.SaveChanges();
        }

        public async Task<IQueryable<CouponDto>> FindAll() {
            var query = await _couponRepository.FindAll();
            return _mapper.Map<List<CouponDto>>(query).AsQueryable();
        }

        public async Task<CouponDto> FindByCondition(Guid idCoupon) {
            var query = await _couponRepository.FindByCondition(x => x.Id == idCoupon);
            return _mapper.Map<CouponDto>(query.FirstOrDefault());
        }

        public async Task<CouponDto> Modify(CouponDto coupon) {
            var entity = _mapper.Map<Coupon>(coupon);
            var modelToUpdate = await _couponRepository.FindByCondition(x => x.Id == entity.Id);
            _couponRepository.Update(modelToUpdate.FirstOrDefault());
            return coupon;
        }

        public async Task<CouponDto> DeleteById(Guid id) {
            var modelToDelete = await _couponRepository.FindByCondition(x => x.Id == id);
            _couponRepository.Delete(modelToDelete.FirstOrDefault());
            return _mapper.Map<CouponDto>(modelToDelete.FirstOrDefault());
        }
    }
}
