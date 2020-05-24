using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models
{
    public class Coupon
    {
        public Coupon()
        {
            CouponDetails = new HashSet<CouponDetail>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        [MaxLength(30, ErrorMessage ="Name can't be longer than 30 digits")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Status is required")]
        public string Status { get; set; } 

        [Required(ErrorMessage = "Discount is required")]
        public int Discount { get; set; }

        [Required(ErrorMessage ="Expiration Date is required ")]
        public DateTime ExpirationDate { get; set; }

        [Required(ErrorMessage = "Foreign key is required")]
        [ForeignKey("ProductDetail")]
        public Guid IdProductDetail { get; set; }
        public ProductDetail ProductDetail { get; set; } 
        public virtual ICollection<CouponDetail> CouponDetails { get; set; }
    }
}
