using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Models.Dtos
{
    public class ProductDetailDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public Guid IdProduct { get; set; }
        public Guid IdStoreCategory { get; set; }
        public string Product { get; set; }
        public string Category { get; set; }
    }
}
