using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Repository.Models
{
    public class User
    {
        public User()
        {
            CouponDetails = new HashSet<CouponDetail>();
            Roles = new HashSet<UserRole>();
        }

        [Key]
        public int Id { get; set; }

        /// Account Data
        [Required(ErrorMessage = "Email is required")]
        [MaxLength(40, ErrorMessage = "Email can't be longer than 40 characters")]
        public virtual string Email { get; set; }

        [Required]
        [StringLength(50)]
        //[Display(Name = nameof(AppResources.UserName), ResourceType = typeof(AppResources))]
        public virtual string UserName { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        public virtual string PasswordHash { get; set; }

        public virtual ICollection<UserRole> Roles { get; set; }
        public virtual ICollection<UserDetail> UserDetails { get; set; }
        public virtual ICollection<CouponDetail> CouponDetails { get; set; } 
    }
}
