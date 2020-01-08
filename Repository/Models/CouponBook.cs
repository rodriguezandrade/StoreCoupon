using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Models
{
    public class CouponBook
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [ForeignKey("BookUser")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        [Required]
        [ForeignKey("BookProduct")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        [Required]
        public string Status { get; set; } 
    }
}
