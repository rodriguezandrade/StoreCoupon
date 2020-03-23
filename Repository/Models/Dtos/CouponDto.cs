using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Models.Dtos
{
    public class CouponDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int Discount { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Guid IdProductDtl { get; set; }
    }
}
