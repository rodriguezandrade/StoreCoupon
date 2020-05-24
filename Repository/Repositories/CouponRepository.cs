using Repository.Data;
using Repository.Models;
using Repository.Repositories.Interfaces;
using Repository.Repositories.Utils;

namespace Repository.Repositories
{
     public class CouponRepository : RepositoryBase<Coupon>, ICouponRepository
    {
        public CouponRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
