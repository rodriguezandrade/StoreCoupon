using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models
{
    public class StoreCategory
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Foreignkey is required")]
        [ForeignKey("FkStore")]
        public Guid IdStore { get; set; }

        public Store FkStore { get; set; }

        [Required(ErrorMessage = "Foreignkey is required")]
        [ForeignKey("FkCategoryStores")] 
        public Guid IdCategoryStore { get; set; }

        public CategoryOfStore FkCategoryStore { get; set; }

        public virtual ICollection<ProductDetail> Products{ get; set; }
    }
}
