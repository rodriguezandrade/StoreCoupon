using Repository.Data;
using Repository.Models;
using Repository.Repositories.Interfaces;
using Repository.Repositories.Utils;

namespace Repository.Repositories
{
    public class StoreCategoryRepository : RepositoryBase<StoreCategory>, IStoreCategoryRepository
    {
        public StoreCategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
