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
        Task<IQueryable<CouponDetails>> GetCoupons();
        void create(CouponDto entity);
        Task<IQueryable<CouponDetails>> FindAll();
        Task<CouponDetails> FindByCondition(Guid idCoupon);
        Task<CouponDto> Modify(CouponDto coupon);
        Task<CouponDto> DeleteById(Guid id);
        Task SaveChage();
    }
}
