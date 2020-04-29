using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Repository.Models
{
    public class StoreCategoy
    {
        public StoreCategoy()
        {
            StoreCategoryDetails = new HashSet<StoreCategoryDetail>();
        }
          
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(60, ErrorMessage = "Name can't be longer than 60 characters")]

        public string Name { get; set; } 

        public virtual ICollection<StoreCategoryDetail> StoreCategoryDetails{ get; set; }
    }
}
 