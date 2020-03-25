using Repository.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IAccountRepository : IRepositoryBase<User>
    {
        Task<IQueryable<User>> GetUserByEmail(string email);
        Task<IQueryable<User>> GetUserName(string username, string password);
        Task<IQueryable<Role>> GetUserRole(int id);
        bool MatchEmailUser(string email);
    }
}
