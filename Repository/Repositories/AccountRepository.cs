using Repository.Data;
using Repository.Models;
using Repository.Repositories.Interfaces;
using Repository.Repositories.Utils;
using System; 
using System.Linq; 
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class AccountRepository : RepositoryBase<User>, IAccountRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public AccountRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task<IQueryable<User>> GetUserByEmail(string email)
        {
            return FindByCondition(x => x.Email == email).Result;

        }

        public async Task<IQueryable<User>> GetUserName(string username, string password)
        {
            return FindByCondition(x => x.UserName == username && x.PasswordHash == password).Result;
            //return _repositoryContext.Users.Select(x => x.UserName == username && x.PasswordHash == password, x => x);
            //return FindByCondition(x => x.UserName == username && x.PasswordHash == password,  x => x.Roles);

        }

        public async Task<IQueryable<Role>> GetUserRole(Guid id)
        {
            return _repositoryContext.Roles.Select(x => x.Id == id).ToList();
        }

        public bool MatchEmailUser(string email)
        {
            return FindByCondition(x => x.Email == email).Result.Any();
        }

    }
}
