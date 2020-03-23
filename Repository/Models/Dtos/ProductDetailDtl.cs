using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Models.Dtos
{
    public class ProductDetailDtl : ProductDetailDto
    {
        public string Product { get; set; }
        public string Category { get; set;  }
    }
}
