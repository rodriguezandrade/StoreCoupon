﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Models
{
    public class Coupon
    { 
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        [MaxLength(30, ErrorMessage ="Name can't be longer than 30 digits")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Status is required")]
        public string Status { get; set; } 
        [Required(ErrorMessage = "Discount is required")]
        public int Discount { get; set; }
        [Required(ErrorMessage ="Expiration Date is required")]
        public DateTime ExpirationDate { get; set; }
        [Required(ErrorMessage = "Foreignkey is required")]
        [ForeignKey("FkProd")]
        public Guid IdProduct { get; set; }
        public Product FkProd { get; set; }
        public virtual ICollection<CouponBook> CouponBooks { get; set; }
    }
}
