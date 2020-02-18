using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Models
{
    public class Store_SubCategoryStore
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Foreignkey is required")]
        [ForeignKey("FkStore")]
        public Guid IdStore { get; set; }
        public Store FkStore { get; set; }
        [Required(ErrorMessage = "Foreignkey is required")]
        [ForeignKey("FkSubCategoryStores")]
        public Guid IdSubCategoryStore { get; set; }
        public SubCategoryStore FkSubCategoryStores { get; set; }


    }
}
