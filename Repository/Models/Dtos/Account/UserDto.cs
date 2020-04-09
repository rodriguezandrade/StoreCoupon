using System;

namespace Repository.Models.Dtos.Account
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Token { get; set; }
        public bool IsEmailConfirmed = true;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Telephone { get; set; }
        public string RFC { get; set; }
        public Guid IdStore { get; set; }
        public Guid IdUser { get; set; }
    }
}
