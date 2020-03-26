using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models
{
    public class CouponDetail
    { 
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Foreign key is required")]
        [ForeignKey("User")]
        public int IdUser { get; set; }

        public User User { get; set; }

        [Required(ErrorMessage = "Foreign key is required")]
        [ForeignKey("Coupon")]
        public Guid IdCoupon { get; set; } 

        public Coupon Coupon { get; set; }

        [Required]
        public string Status { get; set; } 
    }
}
