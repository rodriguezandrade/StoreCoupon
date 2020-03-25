using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models
{
    public class SubCategory
    {
      
        [Key] 
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength (60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MaxLength(120, ErrorMessage = "Description can't be longer than 120 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Foreign key is required")]
        [ForeignKey("Category")]
        public Guid IdCatetory { get; set; }

        public GeneralCategory Category { get; set; }  

        public virtual ICollection<Store> Store { get; set; }
    }

}

