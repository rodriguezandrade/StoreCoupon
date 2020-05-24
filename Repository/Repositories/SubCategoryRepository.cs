using Repository.Repositories.Interfaces;
using Repository.Models;
using Repository.Repositories.Utils;
using Repository.Data;

namespace Repository.Repositories
{
    public class SubCategoryRepository : RepositoryBase<SubCategory>, ISubCategoryRepository
    {
        RepositoryContext _repositoryContext;
        public SubCategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
    }
}
