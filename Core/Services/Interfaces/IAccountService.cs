
using Repository.Models.Dtos.Account;

namespace Core.Services.Interfaces
{
    public interface IAccountService
    {
        UserRoleDto GetUserName(string username, string password);
    }
}
