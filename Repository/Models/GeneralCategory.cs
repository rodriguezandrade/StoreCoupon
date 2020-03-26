using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Repository.Models
{
    public class GeneralCategory
    {
        public GeneralCategory()
        {
            SubCategories = new HashSet<SubCategory>();
        }

        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Name { get; set; } 

        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
  