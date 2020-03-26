using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models
{
    public class StoreCategoryDetail
    {
        public StoreCategoryDetail()
        {
            ProductDetails = new HashSet<ProductDetail>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Foreign key is required")]
        [ForeignKey("Store")]
        public Guid IdStore { get; set; }

        public Store Store { get; set; }

        [Required(ErrorMessage = "Foreign key is required")]
        [ForeignKey("StoreCategory")] 
        public Guid IdStoreCategory { get; set; }

        public StoreCategoy StoreCategory { get; set; }

        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
    }
}
