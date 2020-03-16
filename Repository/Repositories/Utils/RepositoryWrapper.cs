using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Models;
using Repository.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repositories.Utils
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private IGeneralCategoryRepository  _categoryRepository;
        private IRepositoryWrapper  _repositoryWraper;
        private RepositoryContext _repositoryContext; 

        public IGeneralCategoryRepository Category
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new GeneralCategoryRepository(_repositoryContext, _repositoryWraper);
                }

                return _categoryRepository;
            }
        }


        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public List<SubCategory>GetSubCategoriess() {
            return _repositoryContext.SubCategories.Include(x=>x.Category).ToList();
           
        }

        public async Task<IQueryable<Coupon>> GetCoupons() { 
            var query =  await  _repositoryContext.Coupons.Include(x=>x.FkProd).ToListAsync();
            return query.AsQueryable();
        }

        public void save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
