using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        [MaxLength(30,ErrorMessage ="Name can't be longer than 30 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [MaxLength(120, ErrorMessage = "Description can't be longer than 120 characters")]
        public string Description { get; set; }
        [Required(ErrorMessage ="Price is required")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Foreignkey is required")]
        [ForeignKey("StoreProduct")]
        public Guid StoreId { get; set; }
        public virtual Store Store { get; set; }

    }
}
