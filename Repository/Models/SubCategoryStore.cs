using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models
{
    public class SubCategoryStore
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Foreignkey is required")]
        [ForeignKey("FkStores")]
        public Guid IdStore { get; set; }
        public Store FkStores { get; set; }
        public virtual ICollection<SubCategory_Product> SubCategory_Products  { get; set; }
        public virtual ICollection<Store_SubCategoryStore> Store_SubCategoryStores { get; set; }
    }
}
 