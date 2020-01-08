using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Models
{
    public class OwnerStore
    {
        [Key]
        public Guid OwnerStoreId { get; set; }
        [Required(ErrorMessage = "Foreignkey is required")]
        [ForeignKey("OwnerStore")]
        public Guid OwnerId { get; set; }
        public virtual Owner Owner { get; set; }
        [Required(ErrorMessage = "Foreignkey is required")]
        [ForeignKey("StoreOwner")]
        public Guid StoreId { get; set; }
        public virtual Store Store { get; set; }

    }
}
