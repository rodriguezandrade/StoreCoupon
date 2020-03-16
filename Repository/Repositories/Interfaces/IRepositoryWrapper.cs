
using Repository.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        IGeneralCategoryRepository Category { get; }

        List<SubCategory> GetSubCategoriess();
        Task<IQueryable<Coupon>> GetCoupons();
        void save();
    }
}
