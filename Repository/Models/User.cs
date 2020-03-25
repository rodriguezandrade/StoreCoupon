﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Repository.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "FirstName is required")]
        [MaxLength(40, ErrorMessage = "FirstName can't be longer than 40 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        [MaxLength(40, ErrorMessage = "LastName can't be longer than 40 characters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [MaxLength(120, ErrorMessage = "Address can't be longer than 120 characters")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Telephone is required")]
        public int Telephone { get; set; }  

        public virtual ICollection<CouponBook> CouponBooks { get; set; }


        /// Account Data
        [Required(ErrorMessage = "Email is required")]
        [MaxLength(40, ErrorMessage = "Email can't be longer than 40 characters")]
        public virtual string Email { get; set; }
        [Required]
        [StringLength(50)]
        //[Display(Name = nameof(AppResources.UserName), ResourceType = typeof(AppResources))]
        public virtual string UserName { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        public virtual string PasswordHash { get; set; }

        public virtual ICollection<UserRole> Roles { get; set; }
    }
}
