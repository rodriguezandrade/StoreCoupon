using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Models
{
    public class Category_Product
    {
        
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MaxLength (60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Foreignkey is required")]
        [ForeignKey("FkStoreCategory")]
        public Guid IdStoreCategory { get; set; }
        public Store_Category FkStoreCategory { get; set; }
        [Required(ErrorMessage = "Foreignkey is required")] 
        [ForeignKey("FkProduct")]
        public Guid IdProduct { get; set; }
        public Product FkProduct { get; set; } 

    }
}
