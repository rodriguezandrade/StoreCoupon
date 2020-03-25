﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models
{
    public class CouponBook
    { 
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Foreignkey is required")]
        [ForeignKey("FkUser")]
        public int IdUser { get; set; }

        public User FkUser { get; set; }

        [Required(ErrorMessage = "Foreignkey is required")]
        [ForeignKey("FkCoup")]
        public Guid IdCoupon { get; set; } 

        public Coupon FkCoupon { get; set; }

        [Required]
        public string Status { get; set; } 
    }
}
