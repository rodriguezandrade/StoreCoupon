using System;

namespace Repository.Models.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }   
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Telephone { get; set; }
        public string RFC { get; set; }
    }
}
