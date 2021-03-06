﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Repository.Models
{
    public class Product
    {
        public Product()
        {
            ProductDetails = new HashSet<ProductDetail>();
        }

        [Key]
        public Guid Id { get; set; } 

        [Required(ErrorMessage ="Name is required")]
        [MaxLength(30,ErrorMessage ="Name can't be longer than 30 characters")]
        public string Name { get; set; }
          
        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
       
    }
}
