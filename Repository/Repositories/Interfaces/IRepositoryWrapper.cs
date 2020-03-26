using Repository.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        IGeneralCategoryRepository Category { get; }
        List<SubCategory> GetSubCategories();
        Task<IQueryable<Coupon>> GetCoupons();
        Task<IQueryable<Store>> GetStores();
        Task<IQueryable<StoreCategoryDetail>> GetStoreCategories();
        Task<IQueryable<ProductDetail>> GetProductDetails();
        void Save();
    }
}
