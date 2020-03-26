using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models
{
    public class Store
    {
        public Store()
        {
            StoreCategoryDetails = new HashSet<StoreCategoryDetail>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(80, ErrorMessage = "Name can't be longer than 80 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "FiscalName is required")]
        [MaxLength(120, ErrorMessage = "FiscalName can't be longer than 120 characters")]
        public string FiscalName { get; set; }

        [Required(ErrorMessage = "Direction is required")]
        [MaxLength(120, ErrorMessage = "Direction can't be longer than 120 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Telephone is required")]
        public int Telephone { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [MaxLength(40, ErrorMessage = "Email can't be longer than 40 characters")]
        public string Email { get; set; }

        [Required(ErrorMessage ="RFC is required")]
        [MinLength(12,ErrorMessage = "RFC needs 12 characters in length")]
        [MaxLength(12, ErrorMessage = "RFC needs 12 characters in length")]
        public string RFC { get; set; }

        [Required(ErrorMessage = "Foreign key is required")]
        [ForeignKey("SubCategory")]
        public Guid SubCategoryId  { get; set; } 

        public SubCategory SubCategory { get; set; }
        
        public virtual ICollection<StoreCategoryDetail> StoreCategoryDetails { get; set; }
    }
}
