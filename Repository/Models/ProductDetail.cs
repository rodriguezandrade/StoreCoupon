using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models
{
    public class ProductDetail
    {
        public ProductDetail()
        {
            Coupons = new HashSet<Coupon>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MaxLength(220, ErrorMessage = "Description can't be longer than 220 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Foreign key is required")]
        [ForeignKey("FkProduct")]
        public Guid IdProduct { get; set; }

        public Product Product { get; set; }

        [Required(ErrorMessage = "Foreign key is required")]
        [ForeignKey("StoreCategoryDetail")]
        public Guid IdStoreCategoryDetail { get; set; }

        public StoreCategoryDetail StoreCategoryDetail { get; set; }

        public virtual ICollection<Coupon> Coupons { get; set; }
    }
}
