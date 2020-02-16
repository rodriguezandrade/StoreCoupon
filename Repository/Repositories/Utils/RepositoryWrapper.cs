using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Models;
using Repository.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repositories.Utils
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ICategoryRepository  _categoryRepository;
        private ISubCategoryRepository _subCategoryRepository;
        private IRepositoryWrapper  _repositoryWraper;
        private RepositoryContext _repositoryContext; 

        public ICategoryRepository Category
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_repositoryContext, _repositoryWraper);
                }

                return _categoryRepository;
            }
        }


      


        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        /// <summary>
        /// Get the Sub catgories
        /// </summary>
        /// <returns></returns>
        public List<SubCategory>GetSubCategoriess() {
            return _repositoryContext.SubCategories.Include(x=>x.Category).ToList();
            
        }

        public void save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
