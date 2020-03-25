﻿using Repository.Models;
using Repository.Models.Dtos;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface ICouponService
    {
        Task<IQueryable<CouponDto>> GetDetails();
        void create(CouponDto entity);
        Task<IQueryable<CouponDto>> Get();
        Task<CouponDto> FindByCondition(Guid idCoupon);
        Task<CouponDto> Update(CouponDto coupon);
        Task<CouponDto> DeleteById(Guid id);
    }
}
