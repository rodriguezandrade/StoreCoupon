using Repository.Models.Dtos;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface ICouponService
    {
        Task<IQueryable<CouponDto>> GetDetails();
        void Create(CouponDto entity);
        Task<IQueryable<CouponDto>> Get();
        Task<CouponDto> FindByCondition(Guid idCoupon);
        Task<CouponDto> Update(CouponDto coupon);
        Task<CouponDto> DeleteById(Guid id);
    }
}
