using Repository.Models;
using Repository.Models.Dtos;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface ICouponService
    {
        Task<IQueryable<CouponDto>> GetCoupons();
        void create(CouponDto entity);
        Task<IQueryable<CouponDto>> FindAll();
        Task<CouponDto> FindByCondition(Guid idCoupon);
        Task<CouponDto> Modify(CouponDto coupon);
        Task<CouponDto> DeleteById(Guid id);
    }
}
