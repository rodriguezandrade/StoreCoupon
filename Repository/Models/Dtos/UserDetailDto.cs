using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Models.Dtos
{
    public class UserDetailDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Telephone { get; set; }
        public string RFC { get; set; }
        public int IdUser { get; set; }

    }
}
