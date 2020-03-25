using Core.Services.Interfaces;
using Repository.Models.Dtos.Account;
using Repository.Repositories.Interfaces;
using System;
using System.Linq;
using System.Text;

namespace Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _userRepository;

        public AccountService(IAccountRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserRoleDto GetUserName(string username, string password)
        {
            var user = _userRepository.GetUserName(username, password).Result.SingleOrDefault();
            if (user == null)
            {
                return null;
            }

            var result = new UserRoleDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email
            };

            if (user.Roles.Any())
            {
                var roleId = user.Roles.First().RoleId;
                var role = _userRepository.GetUserRole
                    (roleId).Result.SingleOrDefault();

                if (role != null)
                {
                    result.Role = role.Name;
                }
            }

            return result;
        }

        public bool MatchEmailUser(string email)
        {
            var existUser = _userRepository.MatchEmailUser(email);

            if (existUser)
            {
                SendEmailPasswordUser(email);
                return true;
            }

            return false;
        }

        public void SendEmailPasswordUser(string email)
        {
            var user = _userRepository.GetUserByEmail(email).Result.SingleOrDefault();
            if (user != null)
            {
                byte[] data = Convert.FromBase64String(user.PasswordHash);
                var password = Encoding.UTF8.GetString(data);
                //var template = String.Format(AppResources.TemplateForgotPassword, user.Email, password);
                //Mailer.SendMail(user.Email, AppResources.SubjectForgotPassword, template);
            }
        }
    }
}
