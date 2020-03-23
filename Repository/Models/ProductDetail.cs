using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models
{
    public class ProductDetail
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [MaxLength(220, ErrorMessage = "Description can't be longer than 220 characters")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Foreignkey is required")]
        [ForeignKey("FkProduct")]
        public Guid IdProduct { get; set; }
        public Product FkProduct { get; set; }
        [Required(ErrorMessage = "Foreignkey is required")]
        [ForeignKey("FkStoreCategory")]
        public Guid IdStoreCategory { get; set; }
        public Store_Category FkStoreCategory { get; set; }
        public virtual ICollection<Coupon> Coupos { get; set; }
    }
}
