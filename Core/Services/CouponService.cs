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
        public async Task<IQueryable<CouponDto>> GetDetails()
        {
            var query = await _repositoryWrapper.GetCoupons();
            return _mapper.Map<List<CouponDto>>(query).AsQueryable();
        }

        public void Create(CouponDto entity)
        {
            var model = _mapper.Map<Coupon>(entity);
            _couponRepository.Create(model);
        }

        public async Task<IQueryable<CouponDto>> Get()
        {
            var query = await _couponRepository.FindAll();
            return _mapper.Map<List<CouponDto>>(query).AsQueryable();
        }

        public async Task<CouponDto> FindByCondition(Guid idCoupon)
        {
            var query = await _couponRepository.FindByCondition(x => x.Id == idCoupon);
            return _mapper.Map<CouponDto>(query.FirstOrDefault());
        }

        public async Task<CouponDto> Update(CouponDto coupon)
        {
            var entity = _mapper.Map<Coupon>(coupon);
            var modelToUpdate = await _couponRepository.FindByCondition(x => x.Id == entity.Id);
            if (!modelToUpdate.Any())
            {
                throw new ApiException("No se pudo editar el coupon", HttpStatusCode.NotFound);
            }
            _couponRepository.Update(entity);
            return _mapper.Map<CouponDto>(entity);
        }

        public async Task<CouponDto> DeleteById(Guid id)
        {
            var modelToDelete = await _couponRepository.FindByCondition(x => x.Id == id);
            if (!modelToDelete.Any())
            {
                throw new ApiException("No se pudo Eliminar el cupon ", HttpStatusCode.NotFound);
            }

            _couponRepository.Delete(modelToDelete.FirstOrDefault());
            return _mapper.Map<CouponDto>(modelToDelete.FirstOrDefault());
        }
    }
}
