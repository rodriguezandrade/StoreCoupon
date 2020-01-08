using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Repository.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "FirstName is required")]
        [MaxLength(40, ErrorMessage = "FirstName can't be longer than 40 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        [MaxLength(40, ErrorMessage = "LastName can't be longer than 40 characters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [MaxLength(120, ErrorMessage = "Address can't be longer than 120 characters")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [MaxLength(40, ErrorMessage = "Email can't be longer than 40 characters")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Telephone is required")]
        public int Telephone { get; set; }
    }
}
