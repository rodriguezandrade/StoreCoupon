using Repository.Data;
using Repository.Models;
using Repository.Repositories.Interfaces;
using Repository.Repositories.Utils;

namespace Repository.Repositories
{
     public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    { 
        public OwnerRepository(RepositoryContext repositoryContext): base(repositoryContext)
        {
        }
    }
}
