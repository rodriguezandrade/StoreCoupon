using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Repository.Models
{
    public class Role 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        //[Display(Name = nameof(AppResources.Name), ResourceType = typeof(AppResources))]
        public string Name { get; set; }

        public ICollection<UserRole> Users { get; set; }
    }
}
