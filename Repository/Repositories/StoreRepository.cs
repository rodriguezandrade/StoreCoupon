
using Repository.Models;
using Repository.Repositories.Interfaces;
using Repository.Repositories.Utils;
using Repository.Data;
namespace Repository.Repositories
{
    public class StoreRepository : RepositoryBase<Store>, IStoreRepository
    {
        public StoreRepository(RepositoryContext repositoryContext):base(repositoryContext)
        {

        }
    }
}
