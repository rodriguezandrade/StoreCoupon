
using Repository.Data;
using Repository.Models;
using Repository.Repositories.Interfaces;
using Repository.Repositories.Utils;

namespace Repository.Repositories
{
    public class Store_CategoryRepository : RepositoryBase<Store_Category>, IStore_CategoryRepository
    {
        public Store_CategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
