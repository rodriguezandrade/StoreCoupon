using Repository.Data;
using Repository.Models;
using Repository.Repositories.Interfaces;
using Repository.Repositories.Utils;

namespace Repository.Repositories
{
     public class UserRepository : RepositoryBase<User>, IUserRepository
    { 
        public UserRepository(RepositoryContext repositoryContext): base(repositoryContext)
        {

        }
    }
}
