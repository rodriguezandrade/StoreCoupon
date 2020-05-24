using Repository.Data;
using Repository.Models;
using Repository.Repositories.Interfaces;
using Repository.Repositories.Utils;

namespace Repository.Repositories
{
    public class StoreCategoryRepository : RepositoryBase<StoreCategoryDetail>, IStoreCategoryRepository
    {
        public StoreCategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
